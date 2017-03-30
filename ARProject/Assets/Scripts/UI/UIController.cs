using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This class handles all UI input and relays UI commands
 */



public class UIController : MonoBehaviour {

    private LineManager linemanager;
    private CanvasManager canvasmanager;

    private VanyaScript vanya;

    void Awake()
    {
        linemanager = GameObject.Find("CanvasTarget").GetComponent<LineManager>();
        canvasmanager = GameObject.Find("Canvas").GetComponent<CanvasManager>();

        vanya = GameObject.Find("vanyamodel").GetComponent<VanyaScript>();
        
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Touch Input
        int nbTouches = Input.touchCount;

        if (nbTouches > 0)
        {
            for (int i = 0; i < nbTouches; i++)
            {
                Touch touch = Input.GetTouch(i);

                if (touch.phase == TouchPhase.Began)
                {
                    if(touch.tapCount >= 3)
                    {
                        // Quit app
                        Application.Quit();
                    }

                    else
                        linemanager.StartDrawing();
                }
            }
        }

        //if (Input.touchCount > 0 && Input.touchCount < 2 && Input.GetTouch(0).phase == TouchPhase.Began)
        //    linemanager.StartDrawing();

        if (Input.touchCount > 0 && Input.touchCount < 2 && Input.GetTouch(0).phase == TouchPhase.Ended)
            linemanager.StopDrawing();



        // Drawing
        if (Input.GetKeyDown("h"))
            linemanager.StartDrawing();
        
        if (Input.GetKeyDown("space"))
            linemanager.StopDrawing();

        if (Input.GetKeyDown("p"))
            linemanager.UndoLastLine();
            

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


        //Vanya Model 
        if (Input.GetKeyDown("l"))
            vanya.Activate();
        if (Input.GetKeyDown("k"))
            vanya.DeActivate();


    }



}
