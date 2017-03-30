using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanyaScript : MonoBehaviour {


    public GameObject[] meshes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Activate()
    {
        foreach (GameObject i in meshes)
        {
            i.SetActive(true);
        }
    }

    public void DeActivate()
    {
        foreach (GameObject i in meshes)
        {
            i.SetActive(false);
        }
    }
}
