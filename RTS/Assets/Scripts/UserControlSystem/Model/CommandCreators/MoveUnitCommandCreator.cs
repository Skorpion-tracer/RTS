using Assets.Scripts.Utils;
using System;
using Zenject;

public class MoveUnitCommandCreator : CommandCreatorBase<IMoveCommand>
{
    [Inject] private AssetsContext _context;
    protected override void ClassSpecificCommandCreation(Action<IMoveCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new MoveUnitCommand()));
    }
}

