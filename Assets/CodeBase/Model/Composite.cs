using System.Collections.Generic;

namespace CodeBase.Model
{
    public abstract class Composite : Node
    {       
        public List<Node> Children { get; protected set; } = new();

        
        public void AddChild(Node child)
        {
            Children.Add(child);
        }

        public void RemoveChild(Node child)
        {
            Children.Remove(child);
        }
    }
}