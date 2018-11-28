using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlrCamera : MonoBehaviour {
    private GameManager gameMgr;

    [HideInInspector]
    public Bloom bloomLayer = null;
    [HideInInspector]
    public AmbientOcclusion ambientOcclusionLayer = null;
    [HideInInspector]
    public ColorGrading colorGradingLayer = null;
    [HideInInspector]
    public ChromaticAberration chromaticAberration;
    [HideInInspector]
    public PostProcessVolume volume;
    // Use this for initialization
    void Start () {
        gameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();

        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out bloomLayer);
        volume.profile.TryGetSettings(out ambientOcclusionLayer);
        volume.profile.TryGetSettings(out colorGradingLayer);
        volume.profile.TryGetSettings(out chromaticAberration);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
