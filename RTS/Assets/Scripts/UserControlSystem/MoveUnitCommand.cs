using UnityEngine;

public class MoveUnitCommand : IMoveCommand
{
    public Vector3 Target { get; }

    public MoveUnitCommand(Vector3 target)
    {
        Target = target;
    }

    public void CallCommand()
    {
        Debug.Log("Move");
    }
}
