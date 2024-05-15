using UnityEngine;

public abstract class ShapeModel : MonoBehaviour
{
    public RectTransform origin;

    //Upgrades: Perimeter as a variable for Set it only when the size change
    public float GetPerimeter()
    {
        float perimeter = SetPerimeter();
        return perimeter;
    }

    public void SetOrigin(RectTransform newOrigin)
    {
        origin = newOrigin;
    }

    protected abstract float SetPerimeter();
}
