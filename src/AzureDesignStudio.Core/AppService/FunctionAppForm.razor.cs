using AntDesign;

namespace AzureDesignStudio.Core.AppService
{
    public partial class FunctionAppForm
    {
        protected override void PopulateRuntimeStackOptions()
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
                            Value = "dotnet|v3.1",
                            Label = ".NET Core 3.1"
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
                    Value = "5",
                    Label = "PowerShell Core",
                    Children = new CascaderNode[]
                    {
                        new CascaderNode
                        {
                            Value = "PowerShell|7",
                            Label = "7.0"
                        }
                    }
                },
            };
        }
        protected override bool DisableWindowsOption
        {
            get
            {
                if (funcApp.Publish == "docker")
                    return true;

                if (funcApp.RuntimeStack is not null)
                {
                    var stacks = funcApp.RuntimeStack.Split("|");
                    if (stacks[0].Equals("python", StringComparison.InvariantCultureIgnoreCase))
                        return true;
                }

                return false;
            }
        }
    }
}
