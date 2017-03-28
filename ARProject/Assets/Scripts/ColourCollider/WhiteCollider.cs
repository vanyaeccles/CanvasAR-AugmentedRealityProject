using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCollider : MonoBehaviour {

    void Awake()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Green Minus");

        GameObject.Find("CanvasTarget").GetComponent<LineManager>().SetColourWhite();
    }
}
