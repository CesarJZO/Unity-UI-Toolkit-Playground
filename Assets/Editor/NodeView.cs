namespace Editor
{
    public class NodeView : UnityEditor.Experimental.GraphView.Node
    {
        public Node node;

        public NodeView(Node node)
        {
            this.node = node;
            title = node.name;
        }
    }
}
