using AntDesign;

namespace AzureDesignStudio.Components.MenuDrawer
{
    public partial class LoadDrawerTemplate
    {
        internal record TreeData(string Key, string Name, string Value, bool Deletable)
        {
            public List<TreeData> ChildNodes = new();
        }

        Tree<TreeData?> _allDesignTree = null!;
        List<TreeData> _allDesignsData = new();
        bool _loadingDesigns = false;

        private async Task LoadTreeData()
        {
            _loadingDesigns = true;
            var authState = await authenticationStateTask;
            var user = authState.User;
            if (user.Identity?.IsAuthenticated ?? false)
            {
                var (status, savedDesigns) = await _designService.GetAllSavedDesign();
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
                    _allDesignsData.Add(savedData);
                }
            }

            _loadingDesigns = false;
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadTreeData();

            await base.OnInitializedAsync();
        }

        async Task HandleButtonClick()
        {
            DrawerRef<string> dr = (FeedbackRef as DrawerRef<string>)!;
            await dr!.CloseAsync(_allDesignTree.SelectedData?.Value!);
        }

        async Task HandleDelete()
        {
            var name = selectedData?.Value;
            if (string.IsNullOrEmpty(name))
                return;

            var parts = name.Split("://");
            if (parts.Length <= 1)
                return;

            var status = await _designService.DeleteDesign(parts[1]);
            if (status != 200)
            {
                await _messageService.Error($"Failed to delete {parts[1]}");
                return;
            }

            // Reload tree data
            _allDesignsData = new();
            await LoadTreeData();
        }

        private async Task BeginLogin()
        {
            DrawerRef<string> dr = (FeedbackRef as DrawerRef<string>)!;
            await dr!.CloseAsync(string.Empty);

            _navManager.NavigateTo("authentication/login");
        }
    }
}
