using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

    private MeshRenderer meshRend;

	// Use this for initialization
	void Start ()
    {
        meshRend = GetComponent<MeshRenderer>();
        RenderCanvas();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void RenderCanvas()
    {
        meshRend.enabled = !meshRend.enabled;
    } 
}
