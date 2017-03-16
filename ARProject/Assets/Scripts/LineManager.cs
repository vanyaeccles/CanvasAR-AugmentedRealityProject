using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {

    //List of gameobjects to hold the line drawers
    private List<GameObject> lineDrawers = new List<GameObject>();

    //instance of the lineDrawer, basically a gameobject with a line renderer and associated LineRendScript for drawing
    public GameObject lineDrawer;
    private GameObject currentLineDrawer;

    public GameObject paletteCube;
    public GameObject colourSelector;

    public GameObject savedColourBox1;
    public GameObject savedColourBox2;

    public Transform stylusLocation;




    bool isHoldingLineDrawer;

    Color activeColour;
    Color savedColour1;
    Color savedColour2;

    float lineThickness;



    // Use this for initialization
    void Start ()
    {
        activeColour = Color.white;

        lineThickness = 0.1f;

        //SetSelectorCubeColour();

        stylusLocation = GameObject.Find("StylusSphere").GetComponent<Transform>();

        isHoldingLineDrawer = false;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown("h") && !isHoldingLineDrawer)
        {
            lineDrawer = Instantiate(lineDrawer, stylusLocation.position, stylusLocation.rotation);
            lineDrawers.Add(lineDrawer);
            lineDrawer.SendMessage("StartDrawing");
            isHoldingLineDrawer = true;

            SetLineColour();
            SetLineThickness();

            //Debug.Log("Currently Drawing");
        }


        if (Input.GetKeyDown("space") && isHoldingLineDrawer)
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
        lineDrawer.GetComponent<LineRenderer>().startWidth = lineThickness;
        lineDrawer.GetComponent<LineRenderer>().endWidth = lineThickness;
    }

    public void ThicknessPlus()
    {
        lineThickness += 0.5f;
        //Debug.Log("Called");
    }

    public void ThicknessMinus()
    {
        lineThickness -= 0.5f;
    }

    #endregion




    void SetLineColour()
    {
        lineDrawer.GetComponent<LineRenderer>().material.color = activeColour;
    }

    public void SetPaletteCubeColour()
    {
        paletteCube.GetComponent<Renderer>().material.color = activeColour;
    }

    public void SetSelectorCubeColour()
    {
        colourSelector.GetComponent<Renderer>().material.color = activeColour;
        SetPaletteCubeColour();
    }



    #region PLAIN_COLOURS

    public void SetColourBlack()
    {
        activeColour = Color.black;
        SetPaletteCubeColour();
    }

    public void SetColourWhite()
    {
        activeColour = Color.white;
        SetPaletteCubeColour();
    }

    public void SetColourRed()
    {
        activeColour = Color.red;

        SetPaletteCubeColour();
    }


    public void SetColourGreen()
    {
        activeColour = Color.green;

        SetPaletteCubeColour();
    }

    public void SetColourBlue()
    {
        activeColour = Color.blue;

        SetPaletteCubeColour();
    }


    public void SetColourYellow()
    {
        activeColour = Color.yellow;

        SetPaletteCubeColour();
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
        SetPaletteCubeColour();
    }

    public void SetColourSavedCol2()
    {
        activeColour = savedColour2;
        SetPaletteCubeColour();
    }


    #endregion




    #region USER_SELECT_COLOURS

    public void RedChannelPlus()
    {
        Debug.Log("Red Plus");
        if (CheckChannel(0))
            activeColour[0] += 0.1f;
        SetSelectorCubeColour();
    }

    public void RedChannelMinus()
    {
        Debug.Log("Red Minus");
        if (CheckChannel(0))
            activeColour[0] -= 0.1f;
        SetSelectorCubeColour();
    }

    public void BlueChannelPlus()
    {
        Debug.Log("Blue Plus");
        if (CheckChannel(1))
            activeColour[1] += 0.1f;
        SetSelectorCubeColour();
    }

    public void BlueChannelMinus()
    {
        Debug.Log("Blue Minus");
        if (CheckChannel(1))
            activeColour[1] -= 0.1f;
        SetSelectorCubeColour();
    }

    public void GreenChannelPlus()
    {
        Debug.Log("Green Plus");
        if (CheckChannel(2))
            activeColour[2] += 0.1f;
        SetSelectorCubeColour();
    }

    public void GreenChannelMinus()
    {
        Debug.Log("Green Minus");
        if (CheckChannel(2))
            activeColour[2] -= 0.1f;
        SetSelectorCubeColour();
    }


    public bool CheckChannel(int i)
    {
        //Check that the colour falls within the channel range
        if ((activeColour[i] >= 0.0f) && (activeColour[i] <= 1.0f))
            return true;
        else
            return false;
    }

    #endregion
}
