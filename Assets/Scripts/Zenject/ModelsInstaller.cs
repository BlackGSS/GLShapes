using Zenject;

public class ModelsInstaller : Installer<ModelsInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<ShapeModel>().To<SquareModel>().FromComponentInHierarchy().AsCached().NonLazy();
        Container.Bind<ShapeModel>().To<TriangleModel>().FromComponentInHierarchy().AsCached().NonLazy();
        Container.Bind<ShapeModel>().To<RectangleModel>().FromComponentInHierarchy().AsCached().NonLazy();
        Container.Bind<ShapeModel>().To<CircleModel>().FromComponentInHierarchy().AsCached().NonLazy();
        Container.Bind<SquareModel>().FromComponentInHierarchy().AsCached().NonLazy();
        Container.Bind<TriangleModel>().FromComponentInHierarchy().AsCached().NonLazy();
        Container.Bind<RectangleModel>().FromComponentInHierarchy().AsCached().NonLazy();
        Container.Bind<CircleModel>().FromComponentInHierarchy().AsCached().NonLazy();
    }
}