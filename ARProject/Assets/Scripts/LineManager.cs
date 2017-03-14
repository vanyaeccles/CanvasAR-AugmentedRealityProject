using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {

    //List of gameobjects to hold the line drawers
    private List<GameObject> lineDrawers = new List<GameObject>();

    //instance of the lineDrawer, basically a gameobject with a line renderer and associated LineRendScript for drawing
    public GameObject lineDrawer;
    private GameObject currentLineDrawer;


    public Transform stylusLocation;


    bool isHoldingLineDrawer;

    //Color pinkish = new Color(1.0, 0.25, 0.85, 1.0);


    // Use this for initialization
    void Start ()
    {
        stylusLocation = GameObject.Find("StylusSphere").GetComponent<Transform>();

        isHoldingLineDrawer = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("space") && !isHoldingLineDrawer)
        {
            lineDrawer = Instantiate(lineDrawer, stylusLocation.position, stylusLocation.rotation);
            lineDrawers.Add(lineDrawer);
            lineDrawer.SendMessage("StartDrawing");
            isHoldingLineDrawer = true;

            lineDrawer.GetComponent<LineRenderer>().material.color = Color.magenta;

            Debug.Log("Currently Drawing");
        }

        if (Input.GetKeyDown("v") && !isHoldingLineDrawer)
        {
            lineDrawer = Instantiate(lineDrawer, stylusLocation.position, stylusLocation.rotation);
            lineDrawers.Add(lineDrawer);
            lineDrawer.SendMessage("StartDrawing");
            isHoldingLineDrawer = true;

            lineDrawer.GetComponent<LineRenderer>().material.color = Color.white;

            Debug.Log("Currently Drawing");
        }

        if (Input.GetKeyDown("c") && !isHoldingLineDrawer)
        {
            lineDrawer = Instantiate(lineDrawer, stylusLocation.position, stylusLocation.rotation);
            lineDrawers.Add(lineDrawer);
            lineDrawer.SendMessage("StartDrawing");
            isHoldingLineDrawer = true;

            lineDrawer.GetComponent<LineRenderer>().material.color = Color.blue;

            Debug.Log("Currently Drawing");
        }



        if (Input.GetKeyDown("b") && isHoldingLineDrawer)
        {
            // Stop drawing from the current game object
            lineDrawer.SendMessage("StopDrawing");
            isHoldingLineDrawer = false;

            //lineDrawer.GetComponent<LineRendScript>().enabled = false;
            Debug.Log("Stopping Drawing");
        }

    }
}
