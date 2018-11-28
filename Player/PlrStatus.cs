using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlrStatus : MonoBehaviour {

    public float health;
    public bool isDead;
    public GameObject ragdoll;
	// Use this for initialization
	void Start () {
        isDead = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            health = 0;
            isDead = true;
            Die();
        }
	}


    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void Die()
    {
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;

        var _ragdoll = Instantiate(ragdoll, hitPos, hitRot);
        var _ragRigidBody = _ragdoll.GetComponent<Rigidbody>();
        _ragRigidBody.mass = 0.5f;
        _ragRigidBody.AddForce(Vector3.up * 1000f);
        Destroy(gameObject);
    }
}
