﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class LineRendScript : MonoBehaviour {

    List<Vector3> linePoints = new List<Vector3>();
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
        Debug.Log("Drawing 2D");

        RaycastHit hit;
        Ray ray = new Ray(stylusLocation.position, stylusLocation.forward);

        if (Physics.Raycast(ray, out hit))
        {

            //Debug.Log("ray");

            if (hit.collider.tag == "DrawCanvas")
            {

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