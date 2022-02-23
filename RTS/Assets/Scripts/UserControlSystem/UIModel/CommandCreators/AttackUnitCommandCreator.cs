using System;
using Zenject;
using Assets.Scripts.Utils;
using System.Threading;

public class AttackUnitCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
{    protected override IAttackCommand CreateCommand(IAttackable argument) => new AttackUnitCommand(argument);
}