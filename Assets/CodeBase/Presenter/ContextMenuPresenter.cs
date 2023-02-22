using System;
using CodeBase.View;

namespace CodeBase.Presenter
{
    public class ContextMenuPresenter
    {
        private readonly ICreatorNodes _creatorNodes;
        private readonly ContextMenu _contextMenu;

        public ContextMenuPresenter(ICreatorNodes creatorNodes, ContextMenu contextMenu)
        {
            _creatorNodes = creatorNodes;
            _contextMenu = contextMenu;
            
            _contextMenu.AddedTask += ContextMenuOnAddedTask;
            _contextMenu.AddedSequence += ContextMenuOnAddedSequence;
            _contextMenu.AddedSelector += ContextMenuOnAddedSelector;
            _contextMenu.AddedSimpleParallel += ContextMenuOnAddedSimpleParallel;
        }

        private void ContextMenuOnAddedTask(Type type)
        {
            _creatorNodes.AddTask(type);
        }
        
        private void ContextMenuOnAddedSequence()
        {
            _creatorNodes.AddSequence(true);
        }
        
        private void ContextMenuOnAddedSelector()
        {
            _creatorNodes.AddSelector(true);
        }

        private void ContextMenuOnAddedSimpleParallel()
        {
            _creatorNodes.AddSequence(true);
        }
    }
}