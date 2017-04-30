using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class LineRendScript : MonoBehaviour {

    List<Vector3> linePoints = new List<Vector3>();
    List<Vector3> controlPoints = new List<Vector3>();

    LineRenderer lineRenderer;
    public float startWidth = 0.1f;
    public float endWidth = 0.1f;
    public float threshold = 0.1f;
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
    bool drawing3D;


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
        drawing3D = false;
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

    void StartDrawing3D()
    {
        drawing3D = true;
    }

    // Called by Line Manager to stop drawing from this gameobject
    void StopDrawing()
    {
        drawing = false;
        drawing3D = false;
    }

    void Update()
    {
        if (drawing)
        {
            draw2D();
        }

        if (drawing3D)
        {
            draw3D();
        }
    }


    void draw2D()
    {
        //Debug.Log("Drawing 2D");

        RaycastHit hit;
        Ray ray = new Ray(stylusLocation.position, stylusLocation.forward);

        if (Physics.Raycast(ray, out hit))
        {

            //Debug.Log("ray");

            if (hit.collider.tag == "DrawCanvas")
            {
                Debug.Log("Hit canvas");
                //Debug.Log("HIT" + hit.point);
                stylusPos = hit.point;




                // Draw on the canvas plane (0.0 on the y-axis), but in from the last layer so to avoid z-fighting issues
                stylusPos.y += 0.1f + (0.09f * lineIndex);



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

            if (hit.collider.tag == "VanyaModel")
            {
                Debug.Log("Hit vanya");
                //Debug.Log("HIT" + hit.point);
                stylusPos = hit.point;


                // Draw on the canvas plane (0.0 on the y-axis), but in from the last layer so to avoid z-fighting issues
                //stylusPos.y += 0.1f + (0.09f * lineIndex);
                //stylusPos.y -= 0.3f;


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
    }


    void draw3D()
    {
        //float distance = stylusLocation.position.y;
        stylusPos = stylusLocation.position + stylusLocation.forward * 0.5f;
        //stylusPos = stylusLocation.position;
        //Debug.Log("stylusPos" + stylusPos);

        Debug.Log("Drawing 3D");


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

   


    bool CheckThreshold(float _dist)
    {
        //float dist = Vector3.Distance(lastPos, stylusPos);

        //if (_dist <= threshold)
        //    return false;

        if (_dist > threshold)
            return true;

        return false;
    }




    void UpdateLineCatmullRomSpline()
    {
        lineRenderer.SetWidth(startWidth, endWidth);
        lineRenderer.SetVertexCount(linePoints.Count);

        if (lineCount < 4)
        {
            for (int i = lineCount; i < linePoints.Count; i++)
            {
                lineRenderer.SetPosition(i, linePoints[i]);
            }
            lineCount = linePoints.Count;
        }

        if(lineCount > 4)
        {
            genCatmullRomSpline(lineCount);
        }
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



    #region SPLINES

    //Generate the spline bewteen 4 points
    void genCatmullRomSpline(int pos)
    {
        //The 4 points we need for spline between p1 and p2
        Vector3 p0 = linePoints[ClampListPos(pos - 3)];
        Vector3 p1 = linePoints[ClampListPos(pos - 2)];
        Vector3 p2 = linePoints[ClampListPos(pos - 1)];
        Vector3 p3 = linePoints[ClampListPos(pos)];

        //Start position of the line
        Vector3 lastPosition = p1;

        //Spline's resolution
        float splineRes = 0.2f;

        int loops = Mathf.FloorToInt(1f / splineRes);

        int lineIndex = lineCount - 3;

        for (int i = 1; i <= loops; i++)
        {
            //Get the position in the knot sequence
            float knotPos = i * splineRes;

            //Find the coord between end points with the Catmull-Rom spline
            Vector3 newPosition = GetCatmullRomPos(knotPos, p0, p1, p2, p3);

            //Add to line renderer array
            lineRenderer.SetPosition(lineIndex + i, newPosition);


            //Save for the next line segment
            lastPosition = newPosition;
        }
    }

    //Clamp the list positions to allow looping
    int ClampListPos(int pos)
    {
        if (pos < 0)
        {
            pos = lineCount - 1;
        }

        if (pos > lineCount)
        {
            pos = 1;
        }
        else if (pos > lineCount - 1)
        {
            pos = 0;
        }

        return pos;
    }


    //returns the position between 4 points with the Catmull-Rom spline algorithm
    Vector3 GetCatmullRomPos(float knotP, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        //Coefficients of the cubic polynomial
        Vector3 a = 2f * p1;
        Vector3 b = p2 - p0;
        Vector3 c = 2f * p0 - 5f * p1 + 4f * p2 - p3;
        Vector3 d = -p0 + 3f * p1 - 3f * p2 + p3;


        // The cubic polynomial: a + b * knotP + c * knotP^2 + d * knotP^3
        Vector3 position = 0.5f * (a + (b * knotP) + (c * knotP * knotP) + (d * knotP * knotP * knotP));

        return position;
    }


    #endregion


}