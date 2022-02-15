using UnityEngine;

public class PatrolUnitCommand : IPatrolCommand
{
    public void CallCommand()
    {
        Debug.Log("Patrol");
    }
}
