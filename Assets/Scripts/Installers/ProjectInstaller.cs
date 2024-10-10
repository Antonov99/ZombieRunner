using Audio;
using SceneNavigation;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SceneLoader>().AsSingle().NonLazy();
        
        Container.Bind<GameManager.GameManager>().AsSingle().NonLazy();

        Container.BindInterfacesAndSelfTo<AudioController>().AsSingle().NonLazy();
    }
}