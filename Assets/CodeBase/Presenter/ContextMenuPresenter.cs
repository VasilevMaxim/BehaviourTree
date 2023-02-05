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
        }

        private void ContextMenuOnAddedTask(Type type)
        {
            _creatorNodes.AddTask(type);
        }
    }
}