using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCollider : MonoBehaviour {

    void Awake()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Green Minus");

        GameObject.Find("CanvasTarget").GetComponent<LineManager>().SetColourBlack();
    }
}
