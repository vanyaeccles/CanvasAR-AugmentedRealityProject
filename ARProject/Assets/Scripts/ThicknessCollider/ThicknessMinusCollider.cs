using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThicknessMinusCollider : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "StylusSphere")
            GameObject.Find("CanvasTarget").GetComponent<LineManager>().ThicknessMinus();
    }
}
