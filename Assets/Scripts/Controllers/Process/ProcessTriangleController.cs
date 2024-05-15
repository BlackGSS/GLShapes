public class ProcessTriangleController : ProcessShapeController<TriangleModelView, TriangleModel>
{
    protected override void AddListeners()
    {
        shapeView.OnShapeRender += ProcessShape;
    }

    protected override void ProcessShape((string, string) sides)
    {
        shape.leftSideLength = float.Parse(sides.Item1);
        shape.bottomSideLength = float.Parse(sides.Item2);
    }
}
