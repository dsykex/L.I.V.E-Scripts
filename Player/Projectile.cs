﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 5f;
    public float maxDistance = 5f;
    public float damage = 20f;

    //The firerate is how many bullets gets fired per second
    public float fireRate = 4;

    [HideInInspector]
    public GameObject owner;
    private Rigidbody rb;

   
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void OnTriggerEnter(Collider other)
    {
        speed = 0;
        Transform hit = other.transform;
        

        if(hit.tag == "Enemy")
        {
            var enemyStatus = hit.GetComponent<EnemyStatus>();
            enemyStatus.TakeDamage(damage, owner);
        }

        Destroy(gameObject);
        
    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        if (owner != null)
        {
            maxDistance -= 1 * Time.deltaTime;
            if (maxDistance <= 0)
                Destroy(gameObject);

            rb.velocity = transform.forward;
            rb.MovePosition(this.transform.position + rb.velocity * speed * Time.deltaTime);
        }
    }
}
