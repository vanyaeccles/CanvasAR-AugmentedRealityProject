using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCollider : MonoBehaviour {

    void Awake()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    void OnCollisionExit(Collision collision)
    {
        //Debug.Log("Green Minus");
        if (collision.gameObject.tag == "StylusSphere")
            GameObject.Find("CanvasTarget").GetComponent<LineManager>().SetColourWhite();

    }
}
