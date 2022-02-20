using Assets.Scripts.Utils;
using UnityEngine;
using Zenject;

public class UIModelInstaller : MonoInstaller
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _vector3Value;
    [SerializeField] private SelectableValue _selectableValue;
    [SerializeField] private AttackableValue _attackableValue;

    public override void InstallBindings()
    {
        Container.Bind<AssetsContext>().FromInstance(_legacyContext);
        Container.Bind<Vector3Value>().FromInstance(_vector3Value);
        Container.Bind<SelectableValue>().FromInstance(_selectableValue);
        Container.Bind<AttackableValue>().FromInstance(_attackableValue);

        Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IAttackCommand>>().To<AttackUnitCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveUnitCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IPatrolCommand>>().To<PatrolUnitCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IStopCommand>>().To<StopUnitCommandCreator>().AsTransient();

        Container.Bind<CommandButtonsModel>().AsTransient();        
    }
}