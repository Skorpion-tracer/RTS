using Abstractions;
using Assets.Scripts.Utils;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;
    [SerializeField] private AssetsContext _context;

    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectable.OnSelected += onSelected;
        onSelected(_selectable.CurrentValue);

        _view.OnClick += onButtonClick;
    }

    private void onSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
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
    private void onButtonClick(ICommandExecutor commandExecutor)
    {
        var unitProducer = commandExecutor as
        CommandExecutorBase<IProduceUnitCommand>;
        if (unitProducer != null)
        {
            unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
            return;
        }
        if (unitProducer == null)
        {
            if (commandExecutor is UnitAttack unitAttack)
            {
                unitAttack.ExecuteSpecificCommand(_context.Inject(new AttackUnitCommand()));
                return;
            }
            if (commandExecutor is UnitMove unitMove)
            {
                unitMove.ExecuteSpecificCommand(_context.Inject(new MoveUnitCommand()));
                return;
            }
            if (commandExecutor is UnitPatrol unitPatrol)
            {
                unitPatrol.ExecuteSpecificCommand(_context.Inject(new PatrolUnitCommand()));
                return;
            }
            if (commandExecutor is UnitStop unitStop)
            {
                unitStop.ExecuteSpecificCommand(_context.Inject(new StopUnitCommand()));
                return;
            }
        }
        throw new
        ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}: Unknown type of commands executor: { commandExecutor.GetType().FullName }!");
    }
}

