using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThicknessMinusCollider : MonoBehaviour {

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "StylusSphere")
            GameObject.Find("CanvasTarget").GetComponent<LineManager>().ThicknessMinus();
    }
}
