﻿using System.Collections.Generic;
using CodeBase.Model;
using CodeBase.Presenter;
using CodeBase.View;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    internal class CreatorNodes : IGetterNodesView, ICreatorNodes
    {
        private readonly ContainerViewModel _containerViewModel;
        private SequenceView _firstSv;
        private SequenceView _firstSv2;
        private SequenceView _firstSv3;
        private RootView _rootView;
        
        private readonly NodeStyle _style;

        private List<INodeView> _nodesView;
        private Root _rootModel;

        public CreatorNodes(ContainerViewModel containerViewModel)
        {
            _containerViewModel = containerViewModel;
            _style = Resources.Load<NodeStyle>("StyleSequence");
            _nodesView = new List<INodeView>();
        }

        public void Create()
        {
            _rootView = new RootView(_style, new WaypointsDrawer(3), new Vector2(0, 100));
            _rootModel = new Root();
            _containerViewModel.Add(_rootModel, _rootView);
            _nodesView.Add(_rootView);
        }

        public void AddSequence()
        {
            var sequenceView = new SequenceView(_style, new WaypointsDrawer(4),new Vector2(100, 100));
            var sequence = new Sequence();
            var sequencePresenter = new SequencePresenter(sequence, sequenceView, _containerViewModel);
            
            _containerViewModel.Add(sequence, sequenceView);
            _nodesView.Add(sequenceView);
        }

        public IEnumerable<INodeView> GetNodes()
        {
            return _nodesView;
        }
    }
}