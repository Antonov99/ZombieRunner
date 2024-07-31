using Character;
using Animators;
using Money;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] 
    private PlayerService playerService;

    [SerializeField]
    private CollisionHandler collisionHandler;

    [SerializeField]
    private int initialMoney;
    
    public override void InstallBindings()
    {
        //Character
        Container.Bind<PlayerService>().FromInstance(playerService).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InputSystem.InputSystem>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<CharacterMoveController>().AsSingle().NonLazy();

        //Collisions
        Container.Bind<CollisionHandler>().FromInstance(collisionHandler).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ObstacleCollisionObserver>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<CollectibleCollisionObserver>().AsSingle().NonLazy();

        //Managers
        Container.Bind<GameManager.GameManager>().AsSingle().NonLazy();
        
        //Animations
        Container.BindInterfacesAndSelfTo<DeathAnimatorTrigger>().AsSingle().NonLazy();

        //Etc CORE
        Container.
            Bind<IMoneyStorage>().
            To<MoneyStorage>().
            AsSingle().
            WithArguments(initialMoney).
            NonLazy();
    }
}