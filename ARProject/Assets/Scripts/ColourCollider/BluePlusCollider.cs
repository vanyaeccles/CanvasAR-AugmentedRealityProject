﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlusCollider : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Blue Plus");
        if (collision.gameObject.tag == "StylusSphere")
            GameObject.Find("CanvasTarget").GetComponent<LineManager>().BlueChannelPlus();
    }
}
