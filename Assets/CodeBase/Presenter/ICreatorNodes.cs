using System;
using CodeBase.View;

namespace CodeBase.Presenter
{
    public interface ICreatorNodes
    {
        void AddSequence();
        void AddSelector();
        void AddComment();
        void AddBlackboard();
        void AddTask(Type typeNode);
    }
}