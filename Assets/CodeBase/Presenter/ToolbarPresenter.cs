using CodeBase.View;

namespace CodeBase.Presenter
{
    public class ToolbarPresenter
    {
        private readonly MenuBar _menuBar;
        private readonly ICreatorNodes _creatorNodes;

        public ToolbarPresenter(MenuBar menuBar, ICreatorNodes creatorNodes)
        {
            _menuBar = menuBar;
            _creatorNodes = creatorNodes; 
            _menuBar.AddingSequence += MenuBarOnAddingSequence;
            _menuBar.AddingSelector += MenuBarOnAddingSelector;
            _menuBar.AddingBlackboard += MenuBarOnAddingBlackboard;
            _menuBar.AddingComment += MenuBarOnAddingComment;
        }

        private void MenuBarOnAddingBlackboard()
        {
            _creatorNodes.AddBlackboard();
        }

        private void MenuBarOnAddingComment()
        {
            _creatorNodes.AddComment();
        }

        private void MenuBarOnAddingSelector()
        {
            _creatorNodes.AddSelector();
        }

        private void MenuBarOnAddingSequence()
        {
            _creatorNodes.AddSequence();
        }
    }
}