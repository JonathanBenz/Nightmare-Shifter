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
    Health playerHealth;
    NavMeshAgent agent;
    Animator animator;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        // If player is dead, don't do anything more
        if (playerHealth.IsDead) return;
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
        Pursue();

        if (distanceToPlayer < agent.stoppingDistance) // && Vector3.Angle(transform.InverseTransformDirection(transform.forward), player.transform.position) < 45)
        {
            animator.SetTrigger("attack");
        }
    }
    void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    void Pursue()
    {
        Vector3 targetDirection = player.transform.position - this.transform.position;
        float relativeHeading = Vector3.Angle(this.transform.forward, this.transform.TransformVector(player.transform.forward));
        float toTarget = Vector3.Angle(this.transform.forward, this.transform.TransformVector(targetDirection));
        // if agent is in front of target, turn around and seek. Or if target stopped moving, seek. 
        if (toTarget > 90 && relativeHeading < 20 || player.GetComponent<Rigidbody>().velocity.magnitude < 0.05f)
        {
            Seek(player.transform.position);
            return;
        }
        float lookAhead = targetDirection.magnitude / (agent.speed + player.GetComponent<Rigidbody>().velocity.magnitude);
        Seek(player.transform.position + player.transform.forward * lookAhead);
    }
    public void DealDamageToPlayerEvent()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(this.transform.position + transform.forward + transform.up, 0.5f, transform.forward, 1f);

        foreach(RaycastHit hit in hits)
        {
            if(hit.transform.gameObject.tag == "Player")
            {
                hit.transform.gameObject.GetComponent<Health>().LoseHealthPoint();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, aggroRadius);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(this.transform.position, transform.forward * 10f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position + transform.forward + transform.up, 0.5f);
    }
}
