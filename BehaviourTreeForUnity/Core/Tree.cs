namespace BehaviourTree.Core
{
    public class Tree
    {
        private readonly ICompositable _firstComposite;
        private readonly Root _root;

        public Tree(ICompositable firstComposite)
        {
            _firstComposite = firstComposite;
            _root = new Root(_firstComposite);
        }

        public void Run()
        {
            _root.Run();
        }
    }
}