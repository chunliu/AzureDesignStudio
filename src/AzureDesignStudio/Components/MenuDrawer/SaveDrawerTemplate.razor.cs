using AntDesign;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Components.MenuDrawer
{
    internal class DesignName
    {
        [Required]
        public string Name { get; set; } = null!;
    }    
    public partial class SaveDrawerTemplate
    {
        int _savedDesignCount = -1;
        DesignName _designName = null!;
        Form<DesignName> _form = null!;
        private readonly FormValidationRule[] designNameRules = new FormValidationRule[]{
            new FormValidationRule{ Pattern = "^[a-zA-Z0-9\\s]+$", Message = "'Design name' can only have alphanumeric characters." } ,
            new FormValidationRule{ Min=1, Max=200 }
        };

        internal record DesignRecord(string Key, string DesignName);

        List<DesignRecord> _allDesignRecords = default!;
        bool _loadingDesigns = false;

        protected override async Task OnInitializedAsync()
        {
            _loadingDesigns = true;
            _designName = new()
            {
                Name = adsContext.CurrentDesignName
            };
            var authState = await authenticationStateTask;
            var user = authState.User;
            if (user.Identity?.IsAuthenticated ?? false)
            {
                var (status, savedDesigns) = await _designService.GetAllSavedDesign();
                if (status == 200 && savedDesigns != null)
                {
                    _savedDesignCount = savedDesigns.Count;
                    _allDesignRecords = new List<DesignRecord>();
                    for (int i = 0; i < savedDesigns.Count; i++)
                    {
                        _allDesignRecords.Add(new DesignRecord(i.ToString(), savedDesigns[i]));
                    }
                }
            }

            _loadingDesigns = false;

            await base.OnInitializedAsync();
        }

        async void SaveButtonClick()
        {
            if (!_form.Validate())
                return;

            adsContext.CurrentDesignName = _designName.Name;
            DrawerRef<string> dr = (FeedbackRef as DrawerRef<string>)!;
            await dr!.CloseAsync($"save:{adsContext.CurrentDesignName}");
        }

        private async Task BeginLogin()
        {
            DrawerRef<string> dr = (FeedbackRef as DrawerRef<string>)!;
            await dr!.CloseAsync(string.Empty);

            _navManager.NavigateToLogin("authentication/login");
        }

        async Task LoadButtonClick()
        {
            var designName = _selectedRows?.FirstOrDefault()?.DesignName;
            if (string.IsNullOrEmpty(designName))
                return;

            DrawerRef<string> dr = (FeedbackRef as DrawerRef<string>)!;
            await dr!.CloseAsync($"load:{designName}");
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

            _loadingDesigns = true;
            
            var (s, savedDesigns) = await _designService.GetAllSavedDesign();
            if (s == 200 && savedDesigns != null)
            {
                _allDesignRecords = new List<DesignRecord>();
                for (int i = 0; i < savedDesigns.Count; i++)
                {
                    _allDesignRecords.Add(new DesignRecord(i.ToString(), savedDesigns[i]));
                }
            }

            _loadingDesigns = false;
        }
    }
}
