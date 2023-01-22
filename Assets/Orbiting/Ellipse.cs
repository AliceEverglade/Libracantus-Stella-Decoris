using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ellipse
{
    public float xAxis;
    public float zAxis;

    [Range(-1f, 1f)]
    public float xAngle;
    [Range(-1f, 1f)]
    public float yAngle;
    public Planes Plane = Planes.Y;
    public enum Planes
    {
        X,
        Y,
        Z,
    }
    public Ellipse(float xAxis, float zAxis)
    {
        this.xAxis = xAxis;
        this.zAxis = zAxis;
    }

    public Vector3 Evaluate(float t)
    {
        Vector3 output;
        float angle = Mathf.Deg2Rad * 360 * t;
        float x = Mathf.Sin(angle) * xAxis;
        float z = Mathf.Cos(angle) * zAxis;
        float y = 0;
        y = (x * xAngle) + (z * yAngle);
        switch (Plane)
        {
            case Planes.X: output = new Vector3(y, x, z); break;
            case Planes.Y: output = new Vector3(x, y, z); break;
            case Planes.Z: output = new Vector3(z, x, y); break;
            default: output = new Vector3(x, y, z); break;
        }
        return output;
    }
}

