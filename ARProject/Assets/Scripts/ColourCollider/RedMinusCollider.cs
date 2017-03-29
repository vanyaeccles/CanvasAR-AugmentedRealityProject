﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMinusCollider : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Red Minus");
        if (collision.gameObject.tag == "StylusSphere")
            GameObject.Find("CanvasTarget").GetComponent<LineManager>().RedChannelMinus();
    }
}
