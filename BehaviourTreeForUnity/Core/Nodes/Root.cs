namespace BehaviourTree.Core
{
    public class Root : IRoot
    {
        private readonly ICompositable _composite;

        public Root(ICompositable composite)
        {
            _composite = composite;
        }

        public void Run()
        {
            _composite.Run();
        }
    }
}