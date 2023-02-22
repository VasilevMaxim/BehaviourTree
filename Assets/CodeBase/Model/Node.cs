namespace CodeBase.Model
{
    public abstract class Node
    {
        public Node Parent { get; protected set; }

        public abstract Status Update();
        
        public void SetParent(Node value)
        {
            Parent = value;
        }

        public void RemoveParent()
        {
            Parent = null;
        }
    }
}