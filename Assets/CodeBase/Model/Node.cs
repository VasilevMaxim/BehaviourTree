namespace CodeBase.Model
{
    public abstract class Node
    {
        protected Node _parent;
        
        public abstract Status Update();
        
        public void SetParent(Node value)
        {
            _parent = value;
        }
    }
}