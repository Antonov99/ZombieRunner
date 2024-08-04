using SceneNavigation;
using Zenject;

public class SceneNavigationInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SceneLoader>().AsSingle().NonLazy();
    }
}