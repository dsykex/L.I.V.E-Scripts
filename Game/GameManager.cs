using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour {

    private Camera plrCam;

	// Use this for initialization
	void Start ()
    {
        plrCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

      
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HandleNPCKill()
    {

    }
}
