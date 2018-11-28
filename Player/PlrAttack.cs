using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlrAttack : MonoBehaviour {

    public GameObject projectile;
    
    public GameObject shootPoint;
    public FixedButton shootBtn;

    
    [Header("Attack Shake Settings")]
    public float magnitude;
    public float roughness;
    public float fadeinTime;
    public float fadeoutTime;
    
    //The higher the fire rate, the more time between shots
  
    private float nextFireTime = 0;
    private GameManager gameMgr;
    private GameObject plrCamera;

    // Use this for initialization
    void Start ()
    {
        gameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();
        plrCamera = GameObject.Find("PlrCamera");
	}

    void Shoot()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1 / projectile.GetComponent<Projectile>().fireRate;
            var proj = GameObject.Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
            proj.GetComponent<Projectile>().owner = gameObject;
            CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeinTime, fadeoutTime);
        }
    }

	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(1))
        {
            Shoot();
        } 
	}
}
