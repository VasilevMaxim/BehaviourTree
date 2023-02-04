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
        }

        private void MenuBarOnAddingSequence()
        {
            _creatorNodes.AddSequence();
        }
    }
}