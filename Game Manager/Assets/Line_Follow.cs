using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Follow : MonoBehaviour
{
    public Transform ball1;
    public Transform ball2;
    public LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        // Update the positions of the line's endpoints based on the balls' positions
        lineRenderer.SetPosition(0, ball1.position);
        lineRenderer.SetPosition(1, ball2.position);
    }

}