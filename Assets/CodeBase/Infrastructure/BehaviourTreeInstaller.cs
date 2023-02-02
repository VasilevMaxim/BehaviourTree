using System;
using CodeBase.View;

namespace CodeBase.Infrastructure
{
    public class BehaviourTreeInstaller
    {
        private readonly ViewContainer _viewContainer;
        private readonly InputEvents _inputEvents;

        public BehaviourTreeInstaller(Action repaint)
        {
            _inputEvents = new InputEvents(repaint);
            
            CreatorNodes creatorNodes = new CreatorNodes(new ContainerViewModel());
            creatorNodes.Create();
            
            _viewContainer = new ViewContainer(_inputEvents, creatorNodes);
        }

        public void Update()
        {
            CheckInput();
            Draw();
        }
        
        private void Draw()
        {
            _viewContainer.Draw();
        }
        
        private void CheckInput()
        {
            _inputEvents.Check();
        }
    }
}