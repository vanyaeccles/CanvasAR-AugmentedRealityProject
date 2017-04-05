using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

// Sets the camera focus mode

public class FocusScript : MonoBehaviour
{

    void Start()
    {
        bool focusModeSet = CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);

        if (!focusModeSet)
        {
            Debug.Log("Failed to set focus mode (unsupported mode).");
        }
    }

}
    