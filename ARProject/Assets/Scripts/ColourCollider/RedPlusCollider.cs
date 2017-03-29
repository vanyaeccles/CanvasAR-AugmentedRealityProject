﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlusCollider : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Red Plus");
        if (collision.gameObject.tag == "StylusSphere")
            GameObject.Find("CanvasTarget").GetComponent<LineManager>().RedChannelPlus();
    }

   
}
