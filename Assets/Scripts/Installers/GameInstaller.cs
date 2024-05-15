using Character;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] 
    private PlayerService playerService;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputSystem>().AsSingle().NonLazy();
        Container.Bind<PlayerService>().FromInstance(playerService).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<CharacterMoveController>().AsSingle().NonLazy();
    }
}