using AntDesign;

namespace AzureDesignStudio.Components.MenuDrawer
{
    public partial class LoadDrawerTemplate
    {
        internal record DesignRecord(string Key, string DesignName);

        List<DesignRecord> _allDesignRecords = default!;
        bool _loadingDesigns = false;

        private async Task LoadSavedDesign()
        {
            _loadingDesigns = true;
            var authState = await authenticationStateTask;
            var user = authState.User;
            if (user.Identity?.IsAuthenticated ?? false)
            {
                var (status, savedDesigns) = await _designService.GetAllSavedDesign();
                if (status == 200 && savedDesigns != null)
                {
                    _allDesignRecords = new List<DesignRecord>();
                    for(int i = 0; i < savedDesigns.Count; i++)
                    {
                        _allDesignRecords.Add(new DesignRecord(i.ToString(), savedDesigns[i]));
                    }
                }
            }

            _loadingDesigns = false;
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadSavedDesign();

            await base.OnInitializedAsync();
        }

        async Task HandleButtonClick()
        {
            var designName = _selectedRows?.FirstOrDefault()?.DesignName;
            if (string.IsNullOrEmpty(designName))
                return;

            DrawerRef<string> dr = (FeedbackRef as DrawerRef<string>)!;
            await dr!.CloseAsync(designName!);
        }

        async Task HandleDelete()
        {
            var designName = _selectedRows?.FirstOrDefault()?.DesignName;
            if (string.IsNullOrEmpty(designName))
                return;

            var status = await _designService.DeleteDesign(designName);
            if (status != 200)
            {
                await _messageService.Error($"Failed to delete {designName}");
                return;
            }

            await LoadSavedDesign();
        }

        private async Task BeginLogin()
        {
            DrawerRef<string> dr = (FeedbackRef as DrawerRef<string>)!;
            await dr!.CloseAsync(string.Empty);

            _navManager.NavigateTo("authentication/login");
        }
    }
}
