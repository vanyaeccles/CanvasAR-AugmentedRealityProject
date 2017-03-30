using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {

    //List of gameobjects to hold the line drawers
    private List<GameObject> lineDrawers = new List<GameObject>();
    public int lineDrawerIndex;

    //instance of the lineDrawer, basically a gameobject with a line renderer and associated LineRendScript for drawing
    public GameObject baseLineDrawer;
    //This is the one that will 
    private GameObject lineDrawer;

    private LineRenderer paletteLineRenderer;
    private Renderer canRenderer;

    public GameObject paletteCube;
    public GameObject colourSelector;

    public GameObject savedColourBox1;
    public GameObject savedColourBox2;

    public Transform stylusLocation;


    Vector3 drawPos;


    bool isHoldingLineDrawer;
    bool is3d;

    Color activeColour;
    Color savedColour1;
    Color savedColour2;

    public GameObject laser;

    float lineThickness;

    
    // Use this for initialization
    void Start ()
    {
        activeColour = new Color(0.0f, 0.0f, 0.0f);
        lineThickness = 0.1f;

        stylusLocation = GameObject.Find("StylusSphere").GetComponent<Transform>();

        drawPos = new Vector3(0.0f, 0.0f, 0.0f);

        paletteLineRenderer = GameObject.Find("PaletteLine").GetComponent<LineRenderer>();
        canRenderer = GameObject.Find("cantop_default").GetComponent<Renderer>();
        //paletteLineRenderer.material = new Material(Shader.Find("Custom/LineShader"));
        SetPaletteColour();
        SetPaletteLineThickness();

        isHoldingLineDrawer = false;
        is3d = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!is3d)
        {
            RaycastHit hit;
            Ray ray = new Ray(stylusLocation.position, stylusLocation.forward);
            if (Physics.Raycast(ray, out hit))
            {
                float distance = (stylusLocation.position - hit.point).magnitude;
                Debug.DrawRay(stylusLocation.position, stylusLocation.forward * distance, Color.black);

                //ProcessHitObject(hit.collider.tag);

            }
        }

        if(is3d)
        {
            Debug.DrawRay(stylusLocation.position, stylusLocation.forward * 0.5f, Color.red);
        }
        
    }

    
    // This could be used to draw a circle with the specified colour
    public void DrawDot()
    {
        if (!isHoldingLineDrawer)
        {
            if (!is3d)
            {
                
            }

            if (is3d)
            {
                
            }
        }
    }

    public void StartDrawing()
    {
        if (!isHoldingLineDrawer)
        {
            
            lineDrawerIndex = lineDrawers.Count;
            //Debug.Log("lineIndex" + lineDrawerIndex);


            //lineDrawer 
            lineDrawer = Instantiate(baseLineDrawer, drawPos, stylusLocation.rotation);
                
            isHoldingLineDrawer = true;

            SetLineColour();
            SetLineThickness();

            if (!is3d)
            {
                lineDrawer.SendMessage("StartDrawing");
                //Debug.Log("Currently Drawing on the 2D plane");
            }

            if(is3d)
            {
                lineDrawer.SendMessage("StartDrawing3D");
                //Debug.Log("Currently Drawing in 3D");
            }
        }
    }


    public void StopDrawing()
    {
        if (isHoldingLineDrawer)
        {
            lineDrawers.Add(lineDrawer);
            // Stop drawing from the current game object
            lineDrawer.SendMessage("StopDrawing");
            isHoldingLineDrawer = false;

            //lineDrawer.GetComponent<LineRendScript>().enabled = false;
            //Debug.Log("Stopping Drawing");
        }
    }

    public void Toggle3d()
    {
        is3d = !is3d;
    }

    public void UndoLastLine()
    {
        //Destroy(lineDrawers[lineDrawers.Count - 1]);
        //lineDrawers.RemoveAt(lineDrawers.Count - 1);

        RemoveLine(lineDrawers[lineDrawers.Count - 1]);

        Debug.Log("Removing last line");
    }

    void RemoveLine(GameObject lineobject)
    {
        lineDrawers.Remove(lineobject);
        Destroy(lineobject);
    }



    #region THICKNESS


    void SetLineThickness()
    {
        SetPaletteLineThickness();
        lineDrawer.GetComponent<LineRendScript>().setWidth(lineThickness, lineThickness);
    }

    void SetPaletteLineThickness()
    {
        paletteLineRenderer.startWidth = lineThickness;
        paletteLineRenderer.endWidth = lineThickness;
    }

    public void ThicknessPlus()
    {
        lineThickness += 0.05f;
        SetLineThickness();
    }

    public void ThicknessMinus()
    {
        lineThickness -= 0.05f;
        SetLineThickness();
    }

    #endregion




    #region COLOUR_STUFF

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
        canRenderer.material.color = activeColour;
    }

    #endregion



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
