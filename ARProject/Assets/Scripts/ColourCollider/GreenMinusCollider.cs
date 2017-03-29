using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMinusCollider : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Green Minus");
        if (collision.gameObject.tag == "StylusSphere")
            GameObject.Find("CanvasTarget").GetComponent<LineManager>().GreenChannelMinus();
    }
}
