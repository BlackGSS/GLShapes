public class ProcessSquareController : ProcessShapeController<SquareModelView, SquareModel>
{
    protected override void AddListeners()
    {
        shapeView.OnShapeRender += ProcessShape;
    }

    protected override void ProcessShape((string, string) sides)
    {
        shape.sideLength = float.Parse(sides.Item1);
    }
}
