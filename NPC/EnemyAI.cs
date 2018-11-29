using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private NavMeshAgent agent;
    private Animator anim;
    public List<string> TargetList;

    public float movementSpeed;

    public float attackDistance;

    public GameObject target;
    private EnemyStatus status;

    private Rigidbody rb;
    public GameManager gameMgr;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        gameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        anim = GetComponent<Animator>();
        
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        status = GetComponent<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!status.isDead)
        {
            foreach (string tag in TargetList)
            {
                GameObject[] targetList = GameObject.FindGameObjectsWithTag(tag);
                foreach (GameObject enemy in targetList)
                {
                    if (enemy != null)
                    {

                        float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
                        if (target == null)
                        {
                            if (enemyDistance <= 100f)
                            {
                                target = enemy;
                            }
                        }
                        else
                        {
                            float targetDistance = Vector3.Distance(transform.position, target.transform.position);
                            if (enemyDistance < targetDistance)
                                target = enemy;

                            if (targetDistance > 100f)
                                target = null;
                        }

                    }
                    else
                        target = null;
                }

                if (target != null)
                {
                    if (target.GetComponent<PlrStatus>() != null)
                        if (target.GetComponent<PlrStatus>().isDead == true)
                            target = null;
                }


                if (target != null)
                {
                    Debug.Log(CalcMagnitude(gameObject, target));
                    if (CalcMagnitude(gameObject, target) > attackDistance)
                    {
                        anim.SetBool("isChasing", true);
                        anim.SetBool("isAttacking", false);

                       
                        agent.speed = movementSpeed;

                        agent.destination = target.transform.position;


                    }
                    else
                    {
                        anim.SetBool("isAttacking", true);
                        anim.SetBool("isChasing", false);
                    }
                }
                else
                {
                    anim.SetBool("isIdle", true);
                    anim.SetBool("isAttacking", false);
                    anim.SetBool("isChasing", false);
                    agent.enabled = false;
                }

            }
        }else
        {
            agent.Stop();
            rb.Sleep();

            foreach (CharacterJoint joint in GetComponentsInChildren<CharacterJoint>())
                joint.enableProjection = true;

            anim.SetBool("isDead", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isChasing", false);
        }
        
    }

    public float CalcMagnitude(GameObject a, GameObject b)
    {
        Vector3 direction = b.transform.position - a.transform.position;
        direction.y = 0;

        return direction.magnitude;
    }
}
