using Zenject;

public class ModelsInstaller : Installer<ModelsInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<ShapeModel>().To<SquareModel>().FromComponentsInHierarchy().AsSingle().NonLazy();
        Container.Bind<ShapeModel>().To<TriangleModel>().FromComponentsInHierarchy().AsSingle().NonLazy();
        Container.Bind<ShapeModel>().To<RectangleModel>().FromComponentsInHierarchy().AsSingle().NonLazy();
        Container.Bind<ShapeModel>().To<CircleModel>().FromComponentsInHierarchy().AsSingle().NonLazy();
    }
}