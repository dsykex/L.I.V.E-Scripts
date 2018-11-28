using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOD : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        var lodComps = GetComponentsInChildren<LODGroup>();
        var gameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();

        foreach (var lodgroup in lodComps)
        {
            //lodgroup.fadeMode = LODFadeMode.CrossFade;
            //lodgroup.animateCrossFading = true;
            lodgroup.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
