using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EllipseRenderer : MonoBehaviour
{
    LineRenderer lineRenderer;
    [Range(3, 72)]
    [SerializeField] private int segments;
    public Ellipse ellipse;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        CalculateEllipse();
    }

    private void CalculateEllipse()
    {
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i < segments; i++)
        {
            Vector3 position = ellipse.Evaluate(((float)i / (float)segments));
            points[i] = position;
        }
        points[segments] = points[0];
        lineRenderer.positionCount = segments + 1;
        lineRenderer.SetPositions(points);
    }

    private void OnValidate()
    {
        if (Application.isPlaying && lineRenderer != null)
        {
            CalculateEllipse();
        }
    }
}
