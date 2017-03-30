using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThicknessButton : MonoBehaviour {

    public GameObject selectThickness;

    bool isSelectingThickness;


    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "StylusSphere")
    //        colourPanelActivate(isSelectingThickness);
    //}


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "StylusSphere")
        {
            colourPanelActivate(isSelectingThickness);
            isSelectingThickness = !isSelectingThickness;
        }
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
