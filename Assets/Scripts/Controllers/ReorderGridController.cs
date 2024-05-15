using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class ReorderGridController : MonoBehaviour
{
    [SerializeField] private List<RectTransform> positions;
    private CalculatePerimeterController calculatePerimeterController;
    public Action<ShapeModel, RectTransform> OnPositionUpdated;

    [Inject]
    public void Construct(CalculatePerimeterController newCalculatePerimeterController)
    {
        calculatePerimeterController = newCalculatePerimeterController;
    }

    void Start()
    {
        calculatePerimeterController.OnPerimetersCalculated += ReorderGrid;
    }

    private void ReorderGrid(Dictionary<ShapeModel, float> perimeters)
    {
        List<RectTransform> tempPositions = new List<RectTransform>(positions);
        foreach (var shapeModel in perimeters)
        {
            shapeModel.Key.SetOrigin(tempPositions[tempPositions.Count - 1]);
            tempPositions.RemoveAt(tempPositions.Count - 1);
        }
    }
}
