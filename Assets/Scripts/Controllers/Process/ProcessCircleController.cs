public class ProcessCircleController : ProcessShapeController<CircleModelView, CircleModel>
{
    protected override void AddListeners()
    {
        shapeView.OnShapeRender += ProcessShape;
    }

    protected override void ProcessShape((string, string) sides)
    {
        shape.radius = float.Parse(sides.Item1);
        shape.segments = int.Parse(sides.Item2);
    }
}
