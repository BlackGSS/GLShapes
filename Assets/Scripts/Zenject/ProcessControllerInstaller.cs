using Zenject;

public class ProcessControllerInstaller : Installer<ProcessControllerInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<CalculatePerimeterController>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}