using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRagdoll : MonoBehaviour {

    private EnemyStatus enemyStatus;
    private Collider collider;
    
    private Rigidbody rb;

    private void OnEnable()
    {
        SetInitialRefs();
    }

    void SetInitialRefs()
    {
        enemyStatus = transform.root.GetComponent<EnemyStatus>();
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();

        collider.isTrigger = true;
        rb.isKinematic =  true;
        rb.useGravity = false;
    }

   public void Activate()
    {
        rb.isKinematic = false;
        rb.useGravity = true;

        collider.isTrigger = false;
    }
}
