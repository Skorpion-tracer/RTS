using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandCreatorBase<T> where T : ICommand
{
    public ICommandExecutor ProcessCommandExecutor(ICommandExecutor commandExecutor, Action<T> callback)
    {
        var classSpecificCommandExecutor = commandExecutor as CommandCreatorBase<T>;
        if (classSpecificCommandExecutor != null)
        {
            ClassSpecificCommandCreation(callback);
        }

        return commandExecutor;
    }

    protected abstract void ClassSpecificCommandCreation(Action<T> creationCallback);
    public virtual void ProcessCancel() { }
}
