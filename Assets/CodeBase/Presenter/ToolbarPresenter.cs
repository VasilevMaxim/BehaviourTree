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