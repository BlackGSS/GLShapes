using Zenject;

public class ProcessControllerInstaller : Installer<ProcessControllerInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<ProcessSquareController>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<ProcessRectangleController>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<ProcessTriangleController>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<ProcessCircleController>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<Circle>().AsSingle().NonLazy();
        Container.Bind<CalculatePerimeterController>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<ReorderGridController>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}