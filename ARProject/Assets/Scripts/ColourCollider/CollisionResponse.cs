using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionResponse : MonoBehaviour {

	void OnCollisionEnter (Collision collision)
    {
        //Debug.Log("Enter Called");
        if (collision.gameObject.tag == "StylusSphere")
            GameObject.Find("CanvasTarget").GetComponent<LineManager>().SetColourRed();
    }

    //void OnCollisionStay (Collision collision)
    //{
    //    Debug.Log("Stay Occuring");
    //}

    //void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("Exit Called");
    //}
}
