﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {

    public float health = 100;
    public bool isDead;

    private GameManager gameMgr;
    private Animator anim;
    public GameObject ragdoll;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        gameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isDead = false;
	}

    public void TakeDamage(float damage, GameObject attacker)
    {
        health -= damage;

        if (health > 0)
        {
            anim.SetTrigger("takeDamage");
        }
        else
        {
            if(attacker.tag == "Player")
            {
                PlrInfo plrInfo = attacker.GetComponent<PlrInfo>();
                plrInfo.AddPoints(10);
            }
        }
    }

    public void Die()
    {
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
            anim.enabled = false;
       

        foreach (ActivateRagdoll ar in GetComponentsInChildren<ActivateRagdoll>())
            ar.Activate();

        Destroy(gameObject, 3f);
    }


    // Update is called once per frame
    void Update ()
    {
		if(health <= 0)
        {
            health = 0;
            isDead = true;
            gameMgr.HandleNPCKill();
            Die();
        }
	}
}
