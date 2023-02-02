using System.Collections.Generic;

namespace CodeBase.Model
{
    public class Root
    {
        protected List<Node> _children = new ();
        
        public Status Update()
        {
            foreach (var child in _children)
            {
                if (child.Update() == Status.Successful)
                {
                    return Status.Successful;
                }
            }
            
            return Status.Successful;
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