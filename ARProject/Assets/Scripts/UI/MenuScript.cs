using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    public GameObject colourPalette;

    public GameObject thicknessPalette;

    public GameObject dimPalette;

    public GameObject canPalette;

    public GameObject undoButton;

    bool isSelecting;



    void Awake()
    {
        //colourPalettePanelActivate(false);
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with stylus");
        if (collision.gameObject.tag == "StylusSphere")
        {
            colourPalettePanelActivate(isSelecting);
            Debug.Log("Collision with stylus");
        }
            
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
        ActivateColourP(true);

        ActivateThicknessP(true);

        ActivateDimP(true);

        ActivateCanP(true);

        ActivateUndoB(true);

        isSelecting = true;
    }

    void ShutDownAll()
    {
        ActivateColourP(false);

        ActivateThicknessP(false);

        ActivateDimP(false);

        ActivateCanP(false);

        ActivateUndoB(false);

        isSelecting = false;
    }


    void ActivateColourP(bool flag)
    {
        colourPalette.SetActive(flag);
    }

    void ActivateThicknessP(bool flag)
    {
        thicknessPalette.SetActive(flag);
    }

    void ActivateDimP(bool flag)
    {
        dimPalette.SetActive(flag);
    }

    void ActivateCanP(bool flag)
    {
        canPalette.SetActive(flag);
    }

    void ActivateUndoB(bool flag)
    {
        undoButton.SetActive(flag);
    }



}
