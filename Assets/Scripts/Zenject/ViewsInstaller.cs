using Zenject;

public class ViewsInstaller : Installer<ViewsInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<SquareModelView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<RectangleModelView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<TriangleModelView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CircleModelView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ReorderGridView>().FromComponentInHierarchy().AsSingle();
    }
}