using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasButton : MonoBehaviour {

    bool isCanvasOn;

    public TextMesh buttonText;

    void Awake()
    {
        //GameObject.Find("Canvas").GetComponent<CanvasManager>().RenderCanvas();
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "StylusSphere")
    //        GameObject.Find("Canvas").GetComponent<CanvasManager>().RenderCanvas();

    //    buttonText.text = SetText();
    //}

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "StylusSphere")
        {
            GameObject.Find("Canvas").GetComponent<CanvasManager>().RenderCanvas();

            buttonText.text = SetText();

            isCanvasOn = !isCanvasOn;
        }
            
    }

    string SetText()
    {
        if (isCanvasOn)
            return "canvas: on";
        else
            return "canvas: off";
    }
}
