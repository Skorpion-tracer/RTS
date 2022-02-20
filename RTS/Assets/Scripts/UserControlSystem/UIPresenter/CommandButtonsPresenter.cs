﻿using Abstractions;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;

    [Inject] private CommandButtonsModel _model;

    private ISelectable _currentSelectable;

    private void Start()
    {
        _view.OnClick += _model.OnCommandButtonClicked;
        _model.OnCommandSend += _view.UnBlockAllInteractions;
        _model.OnCommandCancel += _view.UnBlockAllInteractions;
        _model.OnCommandAccepted += _view.BlockInteractions;

        _selectable.OnNewValue += OnSelected;
        OnSelected(_selectable.CurrentValue);        
    }

    private void OnSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        if (_currentSelectable != null)
        {
            _model.OnSelectionChanged();
        }
        _currentSelectable = selectable;

        _view.Clear();
        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as
            Component).GetComponentsInParent<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
    }
}

