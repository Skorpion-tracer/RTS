using Assets.Scripts.Utils;
using System;
using Zenject;

public class StopUnitCommandCreator : CommandCreatorBase<IStopCommand>
{
    [Inject] private AssetsContext _context;
    protected override void ClassSpecificCommandCreation(Action<IStopCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new StopUnitCommand()));
    }
}

