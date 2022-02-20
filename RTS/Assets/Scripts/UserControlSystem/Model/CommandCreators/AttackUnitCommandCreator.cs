using System;
using Zenject;
using Assets.Scripts.Utils;

public class AttackUnitCommandCreator : CommandCreatorBase<IAttackCommand>
{
    [Inject] private AssetsContext _context;
    protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new AttackUnitCommand()));
    }
}