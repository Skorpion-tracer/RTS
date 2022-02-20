using UnityEngine;

public class AttackUnitCommand : IAttackCommand
{
    public IAttackable Target { get; }

    public AttackUnitCommand(IAttackable target)
    {
        Target = target;
    }

    public void CallCommand()
    {
        Debug.Log("In Attack!!!");
    }
}

