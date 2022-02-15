using UnityEngine;

public class MoveUnitCommand : IMoveCommand
{
    public void CallCommand()
    {
        Debug.Log("Move");
    }
}
