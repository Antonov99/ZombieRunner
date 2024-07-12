using Character;
using Animators;
using UI;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] 
    private PlayerService playerService;

    [SerializeField]
    private CollisionHandler collisionHandler;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputSystem.InputSystem>().AsSingle().NonLazy();
        Container.Bind<PlayerService>().FromInstance(playerService).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<CharacterMoveController>().AsSingle().NonLazy();

        Container.Bind<CollisionHandler>().FromInstance(collisionHandler).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ObstacleCollisionObserver>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<CollectibleCollisionObserver>().AsSingle().NonLazy();

        Container.Bind<GameManager.GameManager>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<UIManager>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<DeathAnimatorTrigger>().AsSingle().NonLazy();
    }
}