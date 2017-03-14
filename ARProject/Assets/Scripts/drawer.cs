using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawer : MonoBehaviour {

    public GameObject drawObject;

    public Transform stylusLocation;

    //public Vector3 drawPos;

    public Transform canvasPos;

   

    void Awake()
    {
        stylusLocation = GameObject.Find("Sphere").GetComponent<Transform>();

        //canvasPos = GameObject.Find("CanvasTarget").GetComponent<Transform>();
    }


	// Update is called once per frame
	void Update () {

        //Vector3 drawPos = new Vector3(stylusLocation.position.x, canvasPos.position.y, stylusLocation.position.z);

        if (Input.GetKeyDown("space"))
        {

            //Instantiate(drawObject, stylusLocation.position, stylusLocation.rotation);
        }
		
	}
}        
