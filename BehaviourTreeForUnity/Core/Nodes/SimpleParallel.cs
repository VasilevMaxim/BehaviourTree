using System.Collections.Generic;

namespace BehaviourTree.Core
{
    public class SimpleParallel : ICompositable
    {
        private readonly List<INode> _childs = new List<INode>();

        public SimpleParallel(ITask task, INode background)
        {

        }

        public Status Run()
        {
            foreach (var child in _childs)
            {
                if (child.Run() == Status.Fail)
                {
                    return Status.Successful;
                }
            }

            return Status.Fail;
        }

        public void AddChild(INode node)
        {
            _childs.Add(node);
        }
    }
}