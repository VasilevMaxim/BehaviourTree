using System;

namespace BehaviourTree.Core
{
    public class Task : ITask
    {
        private readonly string _text;

        public Task(string text)
        {
            _text = text;
        }

        public Status Run()
        {
            Console.WriteLine(_text);
            return Status.Fail;
        }
    }
}