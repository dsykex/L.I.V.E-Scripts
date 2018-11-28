using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

    [SerializeField] public Light sun;
    [SerializeField] public float minutesInDay = 120f;

    [Range(0, 1)] [SerializeField] private float currentTimeOfDay = 0;
    private float timeMultiplier = 1f;
    private float sunInitialIntensity;
    [SerializeField] private int days;
    private bool survived;

	// Use this for initialization
	void Start ()
    {
        days = 0;
        sunInitialIntensity = sun.intensity;
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateSun();
        currentTimeOfDay += (Time.deltaTime / (minutesInDay * 60)) * timeMultiplier;

        if(currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
	}

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;

        //Nighttime
        if(IsNight())
        {
            GameObject.Find("surviveText").GetComponent<Text>().text = "SURVIVE!!";
            survived = false;
            intensityMultiplier = 0;
        }

        //Sunrise
        else if(currentTimeOfDay >= 0.25f && currentTimeOfDay <= 0.73)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }

        if(isDay())
        {
            if (!survived)
            {
                survived = true;
                days++;
            }

            GameObject.Find("surviveText").GetComponent<Text>().text = string.Format("DAY {0}", days);
        }

        //Sunset
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }

    public bool IsNight()
    {
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            return true;
        }
        return false;
    }

    public bool isDay()
    {
        if (currentTimeOfDay >= 0.30f && currentTimeOfDay <= 0.73)
        {
            return true;
        }
        return false;
    }
}
