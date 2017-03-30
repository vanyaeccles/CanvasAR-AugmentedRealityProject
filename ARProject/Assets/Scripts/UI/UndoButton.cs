using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "StylusSphere")
        {
            GameObject.Find("CanvasTarget").GetComponent<LineManager>().UndoLastLine();
        }

    }

}
