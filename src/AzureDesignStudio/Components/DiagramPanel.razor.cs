using AntDesign;
using AzureDesignStudio.Core;
using AzureDesignStudio.Core.Models;
using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AzureDesignStudio.Components
{
    public partial class DiagramPanel : IDisposable
    {
        private Diagram diagram = null!;
        protected override void OnInitialized()
        {
            base.OnInitialized();

            diagram = adsContext.Diagram;

            DataModelFactory.RegisterAzureModels(diagram);

            diagram.MouseDown += HandleMouseDown;
            diagram.MouseUp += HandleMouseUp;
            diagram.SelectionChanged += HandleSelectionChanged;
        }

        public void Dispose()
        {
            diagram.MouseDown -= HandleMouseDown;
            diagram.MouseUp -= HandleMouseUp;
            diagram.SelectionChanged -= HandleSelectionChanged;
        }

        #region Drag & Drop
        double clientX, clientY = 0;

        private void HandleMouseDown(Model node, MouseEventArgs e)
        {
            clientX = e.ClientX;
            clientY = e.ClientY;
        }

        private void HandleMouseUp(Model node, MouseEventArgs e)
        {
            if ((e.ClientX != clientX || e.ClientY != clientY)
               // && node is not GroupModel
               && node is IAzureNode an
               && node is NodeModel n && n.Group == null)
            {
                var group = GetOverlappedGroup(n);
                var (result, _) = an.IsDrappable(group!);
                if (result)
                {
                    AddNodeToGroup(n, group!);
                }
            }
        }
        /// <summary>
        /// Add a node to a group based on the position of the node.
        /// </summary>
        /// <param name="node"> The node to be added.</param>
        /// <returns>True if the node is added successfully.</returns>
        private static bool AddNodeToGroup(NodeModel node, GroupModel group)
        {
            if (group != null)
            {
                // Set the node's position so the group won't move.
                node.SetPosition(group.Position.X + group.Padding + group.Children.Count, group.Position.Y + group.Padding + group.Children.Count);
                group.AddChild(node);
                return true;
            }

            return false;
        }

        private GroupModel? GetOverlappedGroup(NodeModel node)
        {
            // The node should be added to the group which has the smallest size.
            return diagram.Groups
                .Where(g => g.GetBounds()?.ContainsPoint(node.Position) ?? false)
                .OrderBy(g => g.GetBounds()?.Width * g.GetBounds()?.Height)
                .FirstOrDefault(n => n != node);
        }

        private async Task HandleDrop(DragEventArgs e)
        {
            try
            {
                var position = diagram.GetRelativeMousePoint(e.ClientX, e.ClientY);
                var stencil = adsContext.AllStencils.Single(s => s.Key == adsContext.DraggedStencilKey);
                var node = DataModelFactory.CreateNodeModelFromKey(adsContext.DraggedStencilKey, stencil.Name, stencil.IconPath);
                node.SetPosition(position.X, position.Y);
                var overlappedGroup = GetOverlappedGroup(node);

                var (result, message) = ((IAzureNode)node).IsDrappable(overlappedGroup!);
                if (!result)
                {
                    await messageService.Error(message);
                    return;
                }
                diagram.Batch(() =>
                {
                    if (node is GroupModel g)
                    {
                        diagram.AddGroup(g);
                    }
                    else
                    {
                        diagram.Nodes.Add(node);
                    }
                    AddNodeToGroup(node, overlappedGroup!);
                });
            }
            catch (NotImplementedException)
            {
                await messageService.Info("The component is not implemented yet.");
            }
        }
        #endregion

        #region Drawer
        private async void OpenNodeDrawer()
        {
            var node = diagram.GetSelectedModels().FirstOrDefault();
            if (node is IAzureNode n && n.DataFormType != null)
            {
                RenderFragment drawerContent = builder =>
                {
                    builder.OpenComponent(0, n.DataFormType);
                    builder.CloseComponent();
                };

                RenderFragment child = builder =>
                {
                    builder.OpenComponent<NodeDrawerTemplate>(0);
                    builder.AddAttribute(1, "Node", node);
                    builder.AddAttribute(2, "ChildContent", drawerContent);
                    builder.CloseComponent();
                };

                var options = new DrawerOptions()
                {
                    Title = n.ServiceName,
                    Width = 350,
                    Visible = true,
                    ChildContent = child,
                };
                var drawerRef = await drawerService.CreateAsync(options);
                drawerRef.OnClose = () =>
                {
                    diagram.Batch(() =>
                    {
                        if (node is GroupModel group)
                        {
                            foreach (var c in group.Children)
                                c.Refresh();
                        }
                        node.Refresh();

                    });
                    if (node is NodeModel nm)
                    {
                        nm.Group?.Refresh();
                    }
                    return Task.CompletedTask;
                };
            }
        }

        #endregion

        private bool showCtxMenu = false;
        private bool nodeEditable = false;
        private void HandleSelectionChanged(SelectableModel model)
        {
            var stateChanged = false;
            var selectedCount = diagram.GetSelectedModels().Count();
            var isSelected = selectedCount > 0;
            if (showCtxMenu != isSelected)
            {
                showCtxMenu = isSelected;
                stateChanged = true;
            }

            var isSingleNode = selectedCount == 1;
            if (isSingleNode)
            {
                var node = diagram.GetSelectedModels().FirstOrDefault();
                isSingleNode = node is not LinkModel;
            }

            if (nodeEditable != isSingleNode)
            {
                nodeEditable = isSingleNode;
                stateChanged = true;
            }

            if (stateChanged)
                InvokeAsync(StateHasChanged);
        }
    }
}