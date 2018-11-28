using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float _damage;

    private EnemyAI ai;

    // Use this for initialization
    void Start()
    {
        ai = GetComponent<EnemyAI>();
    }

    public void Attack()
    {
        if (ai.target != null)
        {
            if (ai.target.GetComponent<PlrStatus>() != null)
            {
                ai.target.GetComponent<PlrStatus>().TakeDamage(_damage);
            }
            else
            {
                ai.target.GetComponent<EnemyStatus>().TakeDamage(_damage,gameObject);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
