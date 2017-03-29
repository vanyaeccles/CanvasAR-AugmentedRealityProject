using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMinusCollider : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Blue Minus");
        if (collision.gameObject.tag == "StylusSphere")
            GameObject.Find("CanvasTarget").GetComponent<LineManager>().BlueChannelMinus();
    }
}
