using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace Editor
{
    public class BehaviourTreeView : GraphView
    {
        public new class UxmlFactory : UxmlFactory<BehaviourTreeView, UxmlTraits> { }

        private BehaviourTree _tree;

        public BehaviourTreeView()
        {
            Insert(0, new GridBackground());

            var zoom = new ContentZoomer
            {
                minScale = 0.1f,
                maxScale = 2.0f
            };

            this.AddManipulator(zoom);
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());

            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/BehaviourTreeEditor.uss");
            styleSheets.Add(styleSheet);
        }

        public void PopulateView(BehaviourTree tree)
        {
            _tree = tree;

            DeleteElements(graphElements);

            foreach (Node node in _tree.nodes)
                CreateNodeView(node);
        }

        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            evt.menu.AppendAction("Add node", a => CreateNode());
            evt.menu.AppendAction("Add other node", a => CreateNode());
            // Append a new nested menu under the "Add node" menu item.
            evt.menu.AppendAction("Add nested menu item", a => CreateNode(), DropdownMenuAction.AlwaysEnabled, evt.target);
        }

        private void CreateNode()
        {
            Node node = _tree.CreateNode();
            CreateNodeView(node);
        }

        private void CreateNodeView(Node node)
        {
            var nodeView = new NodeView(node);
            AddElement(nodeView);
        }
    }
}
