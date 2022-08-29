using AntDesign;
using AzureDesignStudio.Models;
using AzureDesignStudio.SharedModels.Protos;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Text;

namespace AzureDesignStudio.Components.MenuDrawer
{
    internal record StepsStatus
    {
        public int CurrentStep { get; set; }
        public string Status { get; set; } = "process";
    }
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
        private SubscriptionRes? _linkedSubscription = null;
        private IList<string> _resourceGroupNames = null!;
        private bool _paramFormLoading = true;
        private bool _showDeployStatus = false;
        private StepsStatus _stepsStatus = new();

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

            if (_drawerContent.Type == CodeDrawerContentType.Json)
            {
                var authState = await authenticationStateTask;
                var user = authState.User;
                if (user.Identity?.IsAuthenticated ?? false)
                {
                    var subscriptions = await _deployService.GetLinkedSubscriptions();
                    if (subscriptions?.Count > 0)
                    {
                        _showDeployButton = true;
                        _linkedSubscription = subscriptions[0];
                    }
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

        async Task HandleDeploy()
        {
            if (_linkedSubscription == null)
                return;

            _paramFormLoading = true;
            _deployParams = new DeploymentParameters();
            _showDeployParams = true;

            _resourceGroupNames = await _deployService.GetResourceGroups(_linkedSubscription.SubscriptionId);

            _paramFormLoading = false;
        }
        private void ParamsFormCancel(MouseEventArgs e)
        {
            _showDeployParams = false;
        }
        private void ParamsFormOk(MouseEventArgs e)
        {
            _paramsForm.Submit();
        }
        private async Task ParamsFormFinish(EditContext editContext)
        {
            _showDeployParams = false;

            _showDeployStatus = true;

            // TODO: work on the parameters.
            await _deployService.CreateDeployment(_linkedSubscription!.SubscriptionId,
                _deployParams.ResourceGroup, _drawerContent.Content, "{}",
                async (deploymentStatus, provisionState) => 
                {
                    var stateHasChanged = false;

                    var step = deploymentStatus switch
                    {
                        "started" => 0,
                        "processing" => 1,
                        "completed" => 2,
                        _ => _stepsStatus.CurrentStep
                    };
                    if (step != _stepsStatus.CurrentStep)
                    {
                        _stepsStatus.CurrentStep = step;
                        stateHasChanged = true;
                    }
                    if (deploymentStatus == "error" && deploymentStatus != _stepsStatus.Status)
                    {
                        _stepsStatus.Status = "error";
                        stateHasChanged = true;
                    }
                    else if (deploymentStatus == "completed")
                    {
                        if (provisionState == "succeeded")
                            _stepsStatus.Status = "finish";
                        else if (provisionState == "failed")
                            _stepsStatus.Status = "error";

                        stateHasChanged = true;
                    }

                    if (stateHasChanged)
                        await InvokeAsync(StateHasChanged);
                });
        }
        private void CloseDeployStatus(MouseEventArgs e)
        {
            _showDeployStatus = false;
            _stepsStatus = new();
        }
    }
}
