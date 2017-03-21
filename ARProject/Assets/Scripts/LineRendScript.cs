using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class LineRendScript : MonoBehaviour {

    List<Vector3> linePoints = new List<Vector3>();
    LineRenderer lineRenderer;
    public float startWidth = 0.1f;
    public float endWidth = 0.1f;
    public float threshold = 0.01f;
    Camera thisCamera;
    int lineCount = 0;

    Vector3 lastPos = Vector3.one * float.MaxValue;

    Vector3 canvasPos;
    Vector3 stylusPos;
    int lineIndex;

    public Transform stylusLocation;
    public Transform canvasLocation;
    
    bool draw;
    bool drawing;

    void Awake()
    {
        thisCamera = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();

        stylusLocation = GameObject.Find("StylusSphere").GetComponent<Transform>();
        canvasLocation = GameObject.Find("CanvasTarget").GetComponent<Transform>();
        canvasPos = canvasLocation.position;

        //stylusPos = GameObject.Find("CanvasTarget").GetComponent<LineManager>().stylusLocation.position;
        lineIndex = GameObject.Find("CanvasTarget").GetComponent<LineManager>().lineDrawerIndex;

        drawing = false;
    }

    public void setWidth(float swidth, float ewidth)
    {
        startWidth = swidth;
        endWidth = ewidth;
    }



    void StartDrawing()
    {
        drawing = true;
    }


    void Update()
    {


        if (drawing)
        {

            stylusPos = stylusLocation.position;
            stylusPos.y = canvasPos.y + (0.1f * lineIndex+1);

            float dist = Vector3.Distance(lastPos, stylusPos);



            if (!CheckThreshold(dist))
            {
                //Debug.Log("Less than threshold! Distance: " + dist);
                draw = false;
                return;
            }

            else
            {
                draw = true;
                //Debug.Log("Greater than threshold! Distance: " + dist);
            }





            if (draw)
            {
                lastPos = stylusPos;

                //If there's nothing in the list, start it
                if (linePoints == null)
                    linePoints = new List<Vector3>();

                

                linePoints.Add(stylusPos);

                UpdateLine();
            }

        }
    }



    bool CheckThreshold(float _dist)
    {
        //float dist = Vector3.Distance(lastPos, stylusPos);

        //if (_dist <= threshold)
        //    return false;

        if (_dist > threshold)
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


    // Called by Line Manager to stop drawing from this gameobject
    void StopDrawing()
    {
        drawing = false;
    }
}