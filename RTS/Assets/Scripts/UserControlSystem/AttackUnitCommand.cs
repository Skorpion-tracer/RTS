using UnityEngine;

public class AttackUnitCommand : IAttackCommand
{
    public void CallCommand()
    {
        Debug.Log("In Attack!!!");
    }
}

