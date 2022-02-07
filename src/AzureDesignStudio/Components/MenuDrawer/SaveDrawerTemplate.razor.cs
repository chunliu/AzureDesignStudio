using AntDesign;
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
        int savedDesignCount = -1;
        DesignName designName = null!;
        Form<DesignName> form = null!;
        private readonly FormValidationRule[] designNameRules = new FormValidationRule[]{
            new FormValidationRule{ Pattern = "^[a-zA-Z0-9\\s]+$", Message = "'Design name' can only have alphanumeric characters." } ,
            new FormValidationRule{ Min=1, Max=200 }
        };

        protected override async Task OnInitializedAsync()
        {
            designName = new()
            {
                Name = adsContext.CurrentDesignName
            };

            var authState = await authenticationStateTask;
            var user = authState.User;
            if (user.Identity?.IsAuthenticated ?? false)
            {
                var (status, names) = await designService.GetAllSavedDesign();
                if (status == 200)
                {
                    savedDesignCount = names?.Count ?? -1;
                }
            }

            await base.OnInitializedAsync();
        }

        async void HandleButtonClick()
        {
            if (!form.Validate())
                return;

            adsContext.CurrentDesignName = designName.Name;
            DrawerRef<string> dr = (FeedbackRef as DrawerRef<string>)!;
            await dr!.CloseAsync(adsContext.CurrentDesignName);
        }

        private async Task BeginLogin()
        {
            DrawerRef<string> dr = (FeedbackRef as DrawerRef<string>)!;
            await dr!.CloseAsync(string.Empty);

            navManager.NavigateTo("authentication/login");
        }
    }
}
