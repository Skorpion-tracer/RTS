using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class UnitMove : CommandExecutorBase<IMoveCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private UnitStop _stopUnit;

    public override async void ExecuteSpecificCommand(IMoveCommand command)
    {
        GetComponent<NavMeshAgent>().destination = command.Target;
        _animator.SetTrigger(Animator.StringToHash("Walk"));
        _stopUnit.CancellationTokenSource = new CancellationTokenSource();
        try
        {
            await _stop
            .WithCancellation
                (
                _stopUnit
                    .CancellationTokenSource
                    .Token
                );
        }
        catch
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            GetComponent<NavMeshAgent>().ResetPath();
        }
        _stopUnit.CancellationTokenSource = null;
        _animator.SetTrigger(Animator.StringToHash("Idle"));

    }
}