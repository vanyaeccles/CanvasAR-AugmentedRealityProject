﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThicknessPlusCollider : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("CanvasTarget").GetComponent<LineManager>().ThicknessPlus();
    }
}
