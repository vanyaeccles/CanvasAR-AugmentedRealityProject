using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveColour2Collider : MonoBehaviour {

    private int votes;
    private int threshold;

    void Awake()
    {
        GetComponent<Renderer>().material.color = Color.white;

        threshold = 50;
    }

    void OnCollisionEnter(Collision collision)
    {

    }

    void OnCollisionStay(Collision collision)
    {
        votes++;
    }

    void OnCollisionExit(Collision collision)
    {
        if (votes < threshold)
        {
            GameObject.Find("CanvasTarget").GetComponent<LineManager>().SetColourSavedCol2();
        }

        if (votes > threshold)
        {
            GameObject.Find("CanvasTarget").GetComponent<LineManager>().SaveColour2();
            Debug.Log("Saving colour 1");
        }

        votes = 0;
    }
}
