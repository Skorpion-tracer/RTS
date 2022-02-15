using UnityEngine;

public class StopUnitCommand : IStopCommand
{
    public void CallCommand()
    {
        Debug.Log("Stop");
    }
}
