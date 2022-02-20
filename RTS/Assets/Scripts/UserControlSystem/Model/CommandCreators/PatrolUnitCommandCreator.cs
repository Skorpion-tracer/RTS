using Assets.Scripts.Utils;
using System;
using Zenject;

public class PatrolUnitCommandCreator : CommandCreatorBase<IPatrolCommand>
{
    [Inject] private AssetsContext _context;
    protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new PatrolUnitCommand()));
    }
}
