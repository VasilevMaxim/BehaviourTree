using System;
using CodeBase.View;

namespace CodeBase.Presenter
{
    public interface ICreatorNodes
    {
        void AddSequence(bool isMousePosition = false);
        void AddSelector(bool isMousePosition = false);
        void AddSimpleParallel(bool isMousePosition = false);
        void AddComment(bool isMousePosition = false);
        void AddBlackboard();
        void AddTask(Type typeNode);
    }
}