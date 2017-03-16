using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMinusCollider : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Green Minus");

        GameObject.Find("CanvasTarget").GetComponent<LineManager>().GreenChannelMinus();
    }
}
