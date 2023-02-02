using System.Collections.Generic;
using CodeBase.Model;
using CodeBase.Presenter;
using CodeBase.View;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    internal class CreatorNodes : IGetterNodesView
    {
        private readonly ContainerViewModel _containerViewModel;
        private SequenceView _firstSv;
        private SequenceView _firstSv2;
        private SequenceView _firstSv3;

        public CreatorNodes(ContainerViewModel containerViewModel)
        {
            _containerViewModel = containerViewModel;
        }

        public void Create()
        {
            NodeStyle style = Resources.Load<NodeStyle>("StyleSequence");

            _firstSv = new SequenceView(style, new WaypointsDrawer(4), new Vector2(0, 100));
            var firstSvModel = new Sequence();
            var firstSvPresenter = new SequencePresenter(firstSvModel, _firstSv, _containerViewModel);
            _containerViewModel.Add(firstSvModel, _firstSv);
            
            _firstSv2 = new SequenceView(style, new WaypointsDrawer(4),new Vector2(100, 100));
            var firstSvModel2 = new Sequence();
            var firstSvPresenter2 = new SequencePresenter(firstSvModel2, _firstSv2, _containerViewModel);
            _containerViewModel.Add(firstSvModel2, _firstSv2);
            
            
            _firstSv3 = new SequenceView(style, new WaypointsDrawer(4),new Vector2(100, 200));
            var firstSvModel3 = new Sequence();
            var firstSvPresenter3 = new SequencePresenter(firstSvModel3, _firstSv3, _containerViewModel);
            _containerViewModel.Add(firstSvModel3, _firstSv3);
        }

        public IEnumerable<INodeView> GetNodes()
        {
            return new[] { _firstSv, _firstSv2, _firstSv3 };
        }
    }
}