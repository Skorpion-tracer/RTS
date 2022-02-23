using UnityEngine;
using Zenject;

public class PatrolUnitCommandCreator : CancellableCommandCreatorBase<IPatrolCommand, Vector3>
{
    [Inject] private SelectableValue _selectable;

    protected override IPatrolCommand CreateCommand(Vector3 argument) => new PatrolUnitCommand(_selectable.CurrentValue.PivotPoint.position, argument);
}