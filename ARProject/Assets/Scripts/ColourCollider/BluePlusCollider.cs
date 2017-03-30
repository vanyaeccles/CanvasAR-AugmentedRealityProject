using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlusCollider : MonoBehaviour {

    void OnCollisionExit(Collision collision)
    {
        //Debug.Log("Blue Plus");
        if (collision.gameObject.tag == "StylusSphere")
            GameObject.Find("CanvasTarget").GetComponent<LineManager>().BlueChannelPlus();
    }
}
