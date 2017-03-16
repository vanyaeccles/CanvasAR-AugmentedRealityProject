using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    public GameObject colourPalette;

    public GameObject thicknessPalette;

    public GameObject basicColourPalette;

    bool isSelecting;


    void OnCollisionEnter(Collision collision)
    {

        colourPalettePanelActivate(isSelecting);
    }


    void colourPalettePanelActivate(bool flag)
    {
        if (!flag)
        {
            ActivateAll();
        }

        if (flag)
        {
            ShutDownAll();
        }
    }


    void ActivateAll()
    {
        colourPalette.SetActive(true);

        thicknessPalette.SetActive(true);

        basicColourPalette.SetActive(true);

        isSelecting = true;
    }

    void ShutDownAll()
    {
        colourPalette.SetActive(false);

        thicknessPalette.SetActive(false);

        basicColourPalette.SetActive(false);

        isSelecting = false;
    }

}
