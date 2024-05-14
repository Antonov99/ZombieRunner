using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InputSystem>().AsSingle().NonLazy();
    }
}