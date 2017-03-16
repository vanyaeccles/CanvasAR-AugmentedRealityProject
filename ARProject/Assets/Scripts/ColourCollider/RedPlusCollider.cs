using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlusCollider : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Red Plus");

        GameObject.Find("CanvasTarget").GetComponent<LineManager>().RedChannelPlus();
    }

   
}
