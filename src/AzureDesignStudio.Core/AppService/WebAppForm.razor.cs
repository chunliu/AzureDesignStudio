using AntDesign;

namespace AzureDesignStudio.Core.AppService
{
    public partial class WebAppForm
    {
        protected virtual void PopulateRuntimeStackOptions()
        {
            RuntimStackOptions = new List<CascaderNode>
            {
                new CascaderNode
                {
                    Value = "1",
                    Label = ".NET",
                    Children = new CascaderNode[]
                    {
                        new CascaderNode
                        {
                            Value = "dotnet|v6.0",
                            Label = ".NET 6"
                        },
                        new CascaderNode
                        {
                            Value = "dotnet|v5.0",
                            Label = ".NET 5"
                        },
                        new CascaderNode
                        {
                            Value = "dotnet|v3.1",
                            Label = ".NET Core 3.1"
                        },
                        new CascaderNode
                        {
                            Value = "dotnet|v4.0",
                            Label = "ASP.NET V4.8",
                            // Disabled = webApp.ServicePlanOS == "linux"
                        }
                    }
                },
                new CascaderNode
                {
                    Value = "2",
                    Label = "Java",
                    Children = new CascaderNode[]
                    {
                        new CascaderNode
                        {
                            Value = "java|11",
                            Label = "Java 11"
                        },
                        new CascaderNode
                        {
                            Value = "java|1.8",
                            Label = "Java 8"
                        }
                    }
                },
                new CascaderNode
                {
                    Value = "3",
                    Label = "Node",
                    Children = new CascaderNode[]
                    {
                        new CascaderNode
                        {
                            Value = "node|~14",
                            Label = "Node 14"
                        },
                        new CascaderNode
                        {
                            Value = "node|~12",
                            Label = "Node 12"
                        }
                    }
                },
                new CascaderNode
                {
                    Value = "4",
                    Label = "PHP",
                    Children = new CascaderNode[]
                    {
                        new CascaderNode
                        {
                            Value = "PHP|8.0",
                            Label = "PHP 8.0",
                        },
                        new CascaderNode
                        {
                            Value = "PHP|7.4",
                            Label = "PHP 7.4"
                        }
                    }
                },
                new CascaderNode
                {
                    Value = "5",
                    Label = "Python",
                    Children = new CascaderNode[]
                    {
                        new CascaderNode
                        {
                            Value = "PYTHON|3.9",
                            Label = "Python 3.9"
                        },
                        new CascaderNode
                        {
                            Value = "PYTHON|3.8",
                            Label = "Python 3.8"
                        },
                        new CascaderNode
                        {
                            Value = "PYTHON|3.7",
                            Label = "Python 3.7"
                        }
                    }
                },
                new CascaderNode
                {
                    Value = "6",
                    Label = "Ruby",
                    Children = new CascaderNode[]
                    {
                        new CascaderNode
                        {
                            Value = "RUBY|2.7",
                            Label = "Ruby 2.7"
                        },
                        new CascaderNode
                        {
                            Value = "RUBY|2.6",
                            Label = "Ruby 2.6"
                        }
                    }
                }
            };
        }
        protected virtual bool DisableWindowsOption
        {
            get
            {
                if (webApp.RuntimeStack is not null)
                {
                    var stacks = webApp.RuntimeStack.Split("|");
                    if (stacks[0].Equals("python", StringComparison.InvariantCultureIgnoreCase)
                        || stacks[0].Equals("ruby", StringComparison.InvariantCultureIgnoreCase)
                        || (stacks[0].Equals("php", StringComparison.InvariantCultureIgnoreCase) 
                            && stacks[1].Equals("8.0", StringComparison.InvariantCultureIgnoreCase)))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        protected virtual bool DisableLinuxOption
        {
            get
            {
                if (webApp.RuntimeStack is not null)
                {
                    var stacks = webApp.RuntimeStack.Split("|");
                    if (stacks[0].Equals("dotnet", StringComparison.InvariantCultureIgnoreCase)
                        && stacks[1].Equals("v4.0", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        private void HandleCascaderChange(CascaderNode[] nodes)
        {
            if (DisableWindowsOption && webApp.ServicePlanOS == "windows")
            {
                webApp.ServicePlanOS = "linux";
                InvokeAsync(StateHasChanged);
            }

            if (DisableLinuxOption && webApp.ServicePlanOS == "linux")
            {
                webApp.ServicePlanOS = "windows";
                InvokeAsync(StateHasChanged);
            }
        }
    }
}
