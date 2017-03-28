using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasButton : MonoBehaviour {

    bool isCanvasOn;

    public TextMesh buttonText;

    void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("Canvas").GetComponent<CanvasManager>().RenderCanvas();

        buttonText.text = SetText();
    }

    void OnCollisionExit(Collision collision)
    {
        isCanvasOn = !isCanvasOn;
    }

    string SetText()
    {
        if (isCanvasOn)
            return "canvas: on";
        else
            return "canvas: off";
    }
}
