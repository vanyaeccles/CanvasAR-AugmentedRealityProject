using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class LineRendScript : MonoBehaviour {

    List<Vector3> linePoints = new List<Vector3>();
    LineRenderer lineRenderer;
    public float startWidth = 0.1f;
    public float endWidth = 0.1f;
    public float threshold = 1.0f;
    Camera thisCamera;
    int lineCount = 0;

    Vector3 lastPos = Vector3.one * float.MaxValue;

    Vector3 canvasPos;
    Vector3 stylusPos;

    public Transform stylusLocation;
    public Transform canvasLocation;
    
    bool draw;
    bool drawing;

    void Awake()
    {
        thisCamera = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();

        stylusLocation = GameObject.Find("Sphere").GetComponent<Transform>();
        canvasLocation = GameObject.Find("CanvasTarget").GetComponent<Transform>();

        canvasPos = canvasLocation.position;

        drawing = false;
    }

    void Update()
    {
         
        if (Input.GetKeyDown("space"))
        {
            drawing = !drawing;
        }


        if (drawing)
        {
            stylusPos = stylusLocation.position;

            //stylusPos.y = canvasPos.y;

            bool isThresholdPassed = CheckThreshold();

            float dist = Vector3.Distance(lastPos, stylusPos);

            if (!CheckThreshold())
            {
                Debug.Log("Threshold not reached! Distance: " + dist);
                Debug.Log("Threshold not reached! Threshold: " + threshold);
                draw = false;
                return;
            }

            if (CheckThreshold())
            {
                draw = true;
                Debug.Log("Threshold reached! Distance: " + dist);
                Debug.Log("Threshold reached! Threshold: " + threshold);
            }


            if (draw)
            {
                lastPos = stylusPos;
                if (linePoints == null)
                    linePoints = new List<Vector3>();
                linePoints.Add(stylusPos);

                UpdateLine();
            }

        }
    }



    bool CheckThreshold()
    {
        float dist = Vector3.Distance(lastPos, stylusPos);

        if (dist <= threshold)
            return false;

        if (dist > threshold)
            return true;

        return false;
    }




    void UpdateLine()
    {
        lineRenderer.SetWidth(startWidth, endWidth);
        lineRenderer.SetVertexCount(linePoints.Count);

        for (int i = lineCount; i < linePoints.Count; i++)
        {
            lineRenderer.SetPosition(i, linePoints[i]);
        }
        lineCount = linePoints.Count;
    }
}