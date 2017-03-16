using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMinusCollider : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Red Minus");

        GameObject.Find("CanvasTarget").GetComponent<LineManager>().RedChannelMinus();
    }
}
