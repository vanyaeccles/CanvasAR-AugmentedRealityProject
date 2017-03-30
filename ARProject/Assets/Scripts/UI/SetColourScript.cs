using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColourScript : MonoBehaviour {

    public GameObject selectColours;

    bool isSelectingColour;


    //void OnCollisionEnter(Collision collision)
    //{
    //    colourPanelActivate(isSelectingColour);
    //}


    void OnCollisionExit(Collision collision)
    {
        colourPanelActivate(isSelectingColour);
        isSelectingColour = !isSelectingColour;
    }


    void colourPanelActivate(bool flag)
    {
        if (!flag)
        {
            selectColours.SetActive(true);
        }

        if (flag)
        {
            selectColours.SetActive(false);
        }

    }
}
