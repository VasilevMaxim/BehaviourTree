using System.Collections.Generic;

namespace CodeBase.View
{
    public class Workspace
    {
        public List<UIElement> UIElements { get; set; }

        public Workspace()
        {
            UIElements = new List<UIElement>();
        }

        public void AddElement(INodeView element)
        {
            UIElements.Add(element);
        }
        
        public void AddElements(IEnumerable<INodeView> element)
        {
            UIElements.AddRange(element);
        }
    }
}