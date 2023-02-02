using System.Collections.Generic;

namespace CodeBase.View
{
    public class Workspace
    {
        public List<INodeView> Nodes { get; }

        public Workspace()
        {
            Nodes = new List<INodeView>();
        }

        public void AddElement(INodeView element)
        {
            Nodes.Add(element);
        }
        
        public void AddElements(IEnumerable<INodeView> element)
        {
            Nodes.AddRange(element);
        }
    }
}