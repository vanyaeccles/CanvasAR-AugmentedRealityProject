using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThicknessMinusCollider : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("CanvasTarget").GetComponent<LineManager>().ThicknessMinus();
    }
}
