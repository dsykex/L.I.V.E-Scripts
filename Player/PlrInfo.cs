using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlrInfo : MonoBehaviour {

    [SerializeField] public int points;

	// Use this for initialization
	void Start () {
		
	}
	
    public void AddPoints(int _points)
    {
        points += _points;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
