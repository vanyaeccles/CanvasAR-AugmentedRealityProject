using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlusCollider : MonoBehaviour {

    void OnCollisionExit(Collision collision)
    {
        //Debug.Log("Green Plus");
        if (collision.gameObject.tag == "StylusSphere")
            GameObject.Find("CanvasTarget").GetComponent<LineManager>().GreenChannelPlus();
    }
}
