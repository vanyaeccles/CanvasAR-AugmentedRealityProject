using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DrawStylusScript : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;

    public GameObject[] stylus;

    void Start()
    {
        stylus = GameObject.FindGameObjectsWithTag("Stylus");

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Draw Stylus when target is tracked
            foreach(GameObject stylusComp in stylus)
            {
                stylusComp.SetActive(true);
            }
            Debug.Log("Tracking Stylus");
        }
        else
        {
            foreach (GameObject stylusComp in stylus)
            {
                // Stop drawing Stylus when target is lost
                stylusComp.SetActive(false);
            }
                
            Debug.Log("Not Tracking Stylus");
        }
    }

}
