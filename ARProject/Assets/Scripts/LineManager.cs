﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {

    //List of gameobjects to hold the line drawers
    private List<GameObject> lineDrawers = new List<GameObject>();
    public int lineDrawerIndex;

    //instance of the lineDrawer, basically a gameobject with a line renderer and associated LineRendScript for drawing
    public GameObject lineDrawer;
    private GameObject currentLineDrawer;

    private LineRenderer paletteLineRenderer;

    public GameObject paletteCube;
    public GameObject colourSelector;

    public GameObject savedColourBox1;
    public GameObject savedColourBox2;

    public Transform stylusLocation;


    Vector3 drawPos;


    bool isHoldingLineDrawer;

    Color activeColour;
    Color savedColour1;
    Color savedColour2;



    float lineThickness;

    
    // Use this for initialization
    void Start ()
    {
        activeColour = new Color(0.0f, 0.0f, 0.0f);
        lineThickness = 0.1f;

        stylusLocation = GameObject.Find("StylusSphere").GetComponent<Transform>();

        drawPos = new Vector3(0.0f, 0.0f, 0.0f);

        paletteLineRenderer = GameObject.Find("PaletteLine").GetComponent<LineRenderer>();
        //paletteLineRenderer.material = new Material(Shader.Find("Custom/LineShader"));
        //paletteLineRenderer.material = new Material(Shader.Find("Unlit"));

        isHoldingLineDrawer = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        drawPos.x = (stylusLocation.position.x);
        drawPos.y = (this.transform.position.y); // + (lineDrawerIndex * 0.1f); // Each line will be further out than the last
        drawPos.z = (stylusLocation.position.z);
    }


    public void StartDrawing()
    {
        if (!isHoldingLineDrawer)
        {
            lineDrawerIndex = lineDrawers.Count;

            lineDrawer = Instantiate(lineDrawer, drawPos, stylusLocation.rotation);
            lineDrawers.Add(lineDrawer);
            lineDrawer.SendMessage("StartDrawing");
            isHoldingLineDrawer = true;

            SetLineColour();
            SetLineThickness();

            //Debug.Log("Currently Drawing");
        }
    }

    public void StopDrawing()
    {
        if (isHoldingLineDrawer)
        {
            // Stop drawing from the current game object
            lineDrawer.SendMessage("StopDrawing");
            isHoldingLineDrawer = false;

            //lineDrawer.GetComponent<LineRendScript>().enabled = false;
            //Debug.Log("Stopping Drawing");
        }
    }


    #region THICKNESS


    void SetLineThickness()
    {
        lineDrawer.GetComponent<LineRendScript>().setWidth(lineThickness, lineThickness);

        paletteLineRenderer.startWidth = lineThickness;
        paletteLineRenderer.endWidth = lineThickness;
    }


    public void ThicknessPlus()
    {
        lineThickness += 0.1f;
        SetLineThickness();
    }

    public void ThicknessMinus()
    {
        lineThickness -= 0.1f;
        SetLineThickness();
    }

    #endregion




    void SetLineColour()
    {
        lineDrawer.GetComponent<LineRenderer>().material.color = activeColour;
        //lineDrawer.GetComponent<LineRenderer>().material.color = Color.red;
    }

    public void SetPaletteCubeColour()
    {
        paletteCube.GetComponent<Renderer>().material.color = activeColour;
    }

    public void SetPaletteColour()
    {
        //colourSelector.GetComponent<Renderer>().material.color = activeColour;
        //SetPaletteCubeColour();

        paletteLineRenderer.material.color = activeColour;
    }



    #region PLAIN_COLOURS

    public void SetColourBlack()
    {
        activeColour = Color.black;
        SetPaletteColour();
    }

    public void SetColourWhite()
    {
        activeColour = Color.white;
        SetPaletteColour();
    }

    public void SetColourRed()
    {
        activeColour = Color.red;

        SetPaletteColour();
    }


    public void SetColourGreen()
    {
        activeColour = Color.green;

        SetPaletteColour();
    }

    public void SetColourBlue()
    {
        activeColour = Color.blue;

        SetPaletteColour();
    }


    public void SetColourYellow()
    {
        activeColour = Color.yellow;

        SetPaletteColour();
    }

    //For saving colours and selecting saved colours

    public void SaveColour1()
    {
        savedColour1 = activeColour;
        savedColourBox1.GetComponent<Renderer>().material.color = activeColour;
    }

    public void SaveColour2()
    {
        savedColour2 = activeColour;
        savedColourBox2.GetComponent<Renderer>().material.color = activeColour;
    }

    public void SetColourSavedCol1()
    {
        activeColour = savedColour1;
        SetPaletteColour();
    }

    public void SetColourSavedCol2()
    {
        activeColour = savedColour2;
        SetPaletteColour();
    }


    #endregion




    #region USER_SELECT_COLOURS

    public void RedChannelPlus()
    {
        Debug.Log("Red Plus");
        if (CheckChannel(0))
            activeColour.r += 0.05f;
        if (activeColour[0] > 1.0f)
            activeColour[0] = 1.0f;
        SetPaletteColour();
    }

    public void RedChannelMinus()
    {
        Debug.Log("Red Minus");
        if (CheckChannel(0))
            activeColour.r -= 0.05f;
        if (activeColour[0] < 0.0f)
            activeColour[0] = 0.0f;
        SetPaletteColour();
    }

    public void BlueChannelPlus()
    {
        Debug.Log("Blue Plus");
        if (CheckChannel(1))
            activeColour[1] += 0.05f;
        if (activeColour[1] > 1.0f)
            activeColour[1] = 1.0f;
        SetPaletteColour();
    }

    public void BlueChannelMinus()
    {
        Debug.Log("Blue Minus");
        if (CheckChannel(1))
            activeColour[1] -= 0.05f;
        if (activeColour[1] < 0.0f)
            activeColour[1] = 0.0f;
        SetPaletteColour();
    }

    public void GreenChannelPlus()
    {
        Debug.Log("Green Plus");
        if (CheckChannel(2))
            activeColour[2] += 0.05f;
        if (activeColour[2] > 1.0f)
            activeColour[2] = 1.0f;
        SetPaletteColour();
    }

    public void GreenChannelMinus()
    {
        Debug.Log("Green Minus");
        if (CheckChannel(2))
            activeColour[2] -= 0.05f;
        if (activeColour[2] < 0.0f)
            activeColour[2] = 0.0f;
        SetPaletteColour();
    }


    public bool CheckChannel(int i)
    {
        //Check that the colour falls within the channel range
        //if ((activeColour[i] > 0.0f) && (activeColour[i] < 1.0f))
            return true;
        //else
        //    return false;
    }

    #endregion
}
