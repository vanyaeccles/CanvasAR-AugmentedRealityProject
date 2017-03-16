using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThicknessButton : MonoBehaviour {

    public GameObject selectThickness;

    bool isSelectingThickness;


    void OnCollisionEnter(Collision collision)
    {
        colourPanelActivate(isSelectingThickness);
    }


    void OnCollisionExit(Collision collision)
    {
        isSelectingThickness = !isSelectingThickness;
    }


    void colourPanelActivate(bool flag)
    {
        if (!flag)
        {
            selectThickness.SetActive(true);
        }

        if (flag)
        {
            selectThickness.SetActive(false);
        }

    }

}
