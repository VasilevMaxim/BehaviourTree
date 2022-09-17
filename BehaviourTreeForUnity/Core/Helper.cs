namespace BehaviourTree.Core
{
    public class Helper
    {
        public Helper()
        {
            var taskRun = new Task("Run");
            var taskWait = new Task("Wait");
            var taskExit = new Task("Exit");

            var sequence = new Sequence();

            sequence.AddChild(taskRun);
            sequence.AddChild(taskWait);
            sequence.AddChild(taskExit);

            var tree = new Tree(sequence);
            tree.Run();
        }
    }
}