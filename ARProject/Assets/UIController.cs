using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This class handles all UI input and relays UI commands
 */



public class UIController : MonoBehaviour {

    private LineManager linemanager;


    void Awake()
    {
        linemanager = GameObject.Find("CanvasTarget").GetComponent<LineManager>();
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
         
        // Drawing
        if (Input.GetKeyDown("h"))
            linemanager.StartDrawing();
        if (Input.GetKeyDown("space"))
            linemanager.StopDrawing();

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

    }



}
