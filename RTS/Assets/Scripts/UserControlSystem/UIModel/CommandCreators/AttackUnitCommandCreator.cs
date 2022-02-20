using System;
using Zenject;
using Assets.Scripts.Utils;

public class AttackUnitCommandCreator : CommandCreatorBase<IAttackCommand>
{
    [Inject] private AssetsContext _context;

    private Action<IAttackCommand> _creationCallback;

    [Inject]
    private void Init(AttackableValue groundClicks)
    {
        groundClicks.OnNewValue += OnNewValue;
    }

    private void OnNewValue(IAttackable attackable)
    {
        _creationCallback?.Invoke(_context.Inject(new AttackUnitCommand(attackable)));
        _creationCallback = null;
    }


    protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
    {
        _creationCallback = creationCallback;
    }

    public override void ProcessCancel()
    {
        base.ProcessCancel();

        _creationCallback = null;
    }
}