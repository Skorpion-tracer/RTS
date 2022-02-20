using UnityEngine;

public class PatrolUnitCommand : IPatrolCommand
{
    public Vector3 From { get; }

    public Vector3 To { get; }

    public PatrolUnitCommand(Vector3 from, Vector3 to)
    {
        From = from;
        To = to;
    }

    public void CallCommand()
    {
        Debug.Log("Patrol");
    }
}
