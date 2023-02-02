using System.Collections.Generic;

namespace CodeBase.Model
{
    public abstract class Composite : Node
    {       
        protected List<Node> _children = new();
        protected Node _parent;

        public void DeleteParent()
        {
            _parent = null;
        }
        
        public void AddChild(Node child)
        {
            _children.Add(child);
        }

        public void RemoveChild(Node child)
        {
            _children.Remove(child);
        }
    }
}