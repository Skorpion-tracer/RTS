using Assets.Scripts.Utils;
using System;
using UnityEngine;
using Zenject;

public class MoveUnitCommandCreator : CancellableCommandCreatorBase<IMoveCommand, Vector3>
{
    protected override IMoveCommand CreateCommand(Vector3 argument) => new MoveUnitCommand(argument);
}

