using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This class handles all UI input and relays UI commands
 */



public class UIController : MonoBehaviour {

    private LineManager linemanager;
    private CanvasManager canvasmanager;


    void Awake()
    {
        linemanager = GameObject.Find("CanvasTarget").GetComponent<LineManager>();
        canvasmanager = GameObject.Find("Canvas").GetComponent<CanvasManager>();
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
         
        // Drawing
        if (Input.GetKeyDown("h") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            linemanager.StartDrawing();
            //Debug.Log("called");
        }
            
        if (Input.GetKeyDown("space") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            linemanager.StopDrawing();

        if (Input.GetKeyDown("p"))
        {
            linemanager.UndoLastLine();
            //Debug.Log("undo");
        }

        // Draw in 3D
        if (Input.GetKeyDown("x"))
            linemanager.Toggle3d();

        // Thickness
        if (Input.GetKeyDown("t"))
            linemanager.ThicknessPlus();
        if (Input.GetKeyDown("y"))
            linemanager.ThicknessMinus();


        // Colours
        if (Input.GetKeyDown("r"))
            linemanager.RedChannelPlus();
        if (Input.GetKeyDown("e"))
            linemanager.RedChannelMinus();

        if (Input.GetKeyDown("g"))
            linemanager.GreenChannelPlus();
        if (Input.GetKeyDown("f"))
            linemanager.GreenChannelMinus();

        if (Input.GetKeyDown("b"))
            linemanager.BlueChannelPlus();
        if (Input.GetKeyDown("v"))
            linemanager.BlueChannelMinus();

        if (Input.GetKeyDown("w"))
            linemanager.SetColourWhite();
        if (Input.GetKeyDown("i"))
            linemanager.SetColourYellow();
        if (Input.GetKeyDown("n"))
            linemanager.SetColourBlue();



        //Canvas 
        if (Input.GetKeyDown("z"))
            canvasmanager.RenderCanvas();



    }



}
