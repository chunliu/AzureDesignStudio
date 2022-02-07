using AntDesign;

namespace AzureDesignStudio.Components.MenuDrawer
{
    public partial class LoadDrawerTemplate
    {
        internal record TreeData(string Key, string Name, string Value, bool Deletable)
        {
            public List<TreeData> ChildNodes = new();
        }

        Tree<TreeData?> allDesignTree = null!;
        List<TreeData> allDesignsData = new();
        bool loadingDesigns = false;

        private async Task LoadTreeData()
        {
            loadingDesigns = true;
            var authState = await authenticationStateTask;
            var user = authState.User;
            if (user.Identity?.IsAuthenticated ?? false)
            {
                var (status, savedDesigns) = await designService.GetAllSavedDesign();
                if (status == 200)
                {
                    var savedData = new TreeData("saved-designs", "Your saved designs", string.Empty, false);
                    if (savedDesigns?.Count == 0)
                    {
                        savedData.ChildNodes.Add(new TreeData($"no-saved-design", "You don't have saved design", string.Empty, false));
                    }
                    else
                    {
                        foreach (var name in savedDesigns!)
                        {
                            savedData.ChildNodes.Add(new TreeData($"db:{name}", name, $"usedb://{name}", true));
                        }
                    }
                    allDesignsData.Add(savedData);
                }
            }
            allDesignsData.Add(
                new("samples", "Samples", string.Empty, false)
                {
                    ChildNodes = new List<TreeData>
                    {
                        new ("gallery:Hub and Spoke Networking", "Hub and Spoke Networking", "gallery/hub-spoke-final.json", false),
                    }
                }
            );
            loadingDesigns = false;
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadTreeData();

            await base.OnInitializedAsync();
        }

        async Task HandleButtonClick()
        {
            DrawerRef<string> dr = (FeedbackRef as DrawerRef<string>)!;
            await dr!.CloseAsync(allDesignTree.SelectedData?.Value!);
        }

        async Task HandleDelete()
        {
            var name = selectedData?.Value;
            if (string.IsNullOrEmpty(name))
                return;

            var parts = name.Split("://");
            if (parts.Length <= 1)
                return;

            var status = await designService.DeleteDesign(parts[1]);
            if (status != 200)
            {
                await messageService.Error($"Failed to delete {parts[1]}");
                return;
            }

            // Reload tree data
            allDesignsData = new();
            await LoadTreeData();
        }
    }
}
