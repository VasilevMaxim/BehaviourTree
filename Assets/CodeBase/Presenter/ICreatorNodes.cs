using System;
using CodeBase.View;

namespace CodeBase.Presenter
{
    public interface ICreatorNodes
    {
        void AddSequence();
        void AddSelector();
        void AddTask(Type typeNode);
    }
}