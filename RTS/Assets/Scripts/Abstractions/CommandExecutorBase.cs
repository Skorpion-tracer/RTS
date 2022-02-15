using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor
{
    public void ExecuteCommand(object command) => ExecuteCommand((T)command);
    public abstract void ExecuteSpecificCommand<T>(T command) where T : ICommand;
}
