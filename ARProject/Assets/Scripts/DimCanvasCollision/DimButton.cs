using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DimButton : MonoBehaviour {

    bool is2D;

    public TextMesh buttonText; 


    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("CanvasTarget").GetComponent<LineManager>().Toggle3d();

        buttonText.text = SetText();
    }


    void OnCollisionExit(Collision collision)
    {
        is2D = !is2D;
    }

    string SetText()
    {
        if (is2D)
            return "2D";
        else
            return "3D";
    }

}