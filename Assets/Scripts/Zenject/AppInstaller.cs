using Zenject;

public class AppInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        ModelsInstaller.Install(Container);
        ViewsInstaller.Install(Container);
        ProcessControllerInstaller.Install(Container);
    }
}
