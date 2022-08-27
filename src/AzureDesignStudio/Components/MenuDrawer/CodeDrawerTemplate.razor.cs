using AntDesign;
using AzureDesignStudio.Models;
using AzureDesignStudio.SharedModels.Protos;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Text;

namespace AzureDesignStudio.Components.MenuDrawer
{
    public partial class CodeDrawerTemplate
    {
        private CodeDrawerContent _drawerContent = null!;
        private string _codeClass = "line-numbers language-json";
        private const string upperRight = "position:absolute;top:86px;right:41px;z-index:10";
        private string _buttonStyle = upperRight;
        private bool _showDeployButton = false;
        private bool _showDeployParams = false;
        private DeploymentParameters _deployParams = null!;
        private Form<DeploymentParameters> _paramsForm = null!;
        private string? _subName = null;

        #region Button style and download
        protected override async Task OnInitializedAsync()
        {
            _drawerContent = Options;
            _codeClass = _drawerContent.Type switch
            {
                CodeDrawerContentType.Bicep => "line-numbers language-bicep",
                CodeDrawerContentType.Json => "line-numbers language-json",
                _ => "line-numbers language-json"
            };

            var authState = await authenticationStateTask;
            var user = authState.User;
            if (user.Identity?.IsAuthenticated ?? false)
            {
                var subscriptions = await _deployService.GetLinkedSubscriptions();
                if (subscriptions?.Count > 0)
                {
                    _showDeployButton = true;
                    _subName = subscriptions[0];
                }
            }

            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            await JS.InvokeVoidAsync("Prism.highlightAll");
        }

        void HandleAffixChange(bool status)
        {
            if (status)
            {
                _buttonStyle = "float:right;";
            }
            else
            {
                _buttonStyle = upperRight;
            }
        }

        async Task HandleDownload()
        {
            var filename = _drawerContent.Type switch
            {
                CodeDrawerContentType.Json => "azure-design-studio.json",
                CodeDrawerContentType.Bicep => "azure-design-studio.bicep",
                _ => "azure-design-studio.json"
            };

            await DownloadFile(_drawerContent.Content, filename, "application/json");
        }

        // According to: https://docs.microsoft.com/en-us/aspnet/core/blazor/file-downloads?view=aspnetcore-6.0
        private async Task DownloadFile(string content, string filename, string contentType)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            using var streamRef = new DotNetStreamReference(stream);
            await JS.InvokeVoidAsync("downloadFileFromStream", filename, contentType, streamRef);
        }
        #endregion

        void HandleDeploy()
        {
            if (string.IsNullOrEmpty(_subName))
                return;

            _deployParams = new DeploymentParameters();
            _showDeployParams = true;
        }
        private void ParamsFormCancel(MouseEventArgs e)
        {
            _showDeployParams = false;
        }
        private void ParamsFormOk(MouseEventArgs e)
        {
            _paramsForm.Submit();
        }
        private void ParamsFormFinish(EditContext editContext)
        {
            _showDeployParams = false;
        }
    }
}
