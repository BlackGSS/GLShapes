public class ProcessRectangleController : ProcessShapeController<RectangleModelView, RectangleModel>
{
    protected override void AddListeners()
    {
        shapeView.OnShapeRender += ProcessShape;
    }

    protected override void ProcessShape((string, string) sides)
    {
        shape.height = float.Parse(sides.Item1);
        shape.width = float.Parse(sides.Item2);
    }
}
