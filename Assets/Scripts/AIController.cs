using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] float aggroRadius = 10f;
    bool isAggro;
    float distanceToPlayer;

    public Action ZombieGroan;

    GameObject player;
    NavMeshAgent agent;
    Animator animator;
    ZombieSFXPlayer zombieSFX;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        zombieSFX = GetComponent<ZombieSFXPlayer>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        if (distanceToPlayer < aggroRadius) isAggro = true;
        if (isAggro)
        {
            AggroBehavior();
        }
    }

    public void AggroBehavior()
    {
        animator.ResetTrigger("attack");
        if (!animator.GetBool("scream")) ZombieGroan.Invoke();
        animator.SetBool("scream", true);
        animator.SetBool("isAggro", true);

        // If transitioning from scream or attack state, do not move
        if(animator.IsInTransition(0))
        {
            return;
        }
        agent.speed = animator.velocity.magnitude;
        agent.SetDestination(player.transform.position);

        if (distanceToPlayer < agent.stoppingDistance) // && Vector3.Angle(transform.InverseTransformDirection(transform.forward), player.transform.position) < 45)
        {
            animator.SetTrigger("attack");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, aggroRadius);
    }
}
