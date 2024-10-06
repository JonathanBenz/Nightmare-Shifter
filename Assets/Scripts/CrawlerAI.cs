using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class CrawlerAI : MonoBehaviour
{
    [SerializeField] float aggroRadius = 8f;
    bool isAggro;
    float distanceToPlayer;

    GameObject player;
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
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        if (distanceToPlayer < aggroRadius)
        {
            if (!isAggro) GetComponent<ZombieSFXPlayer>().PlayZombieSFX();
            isAggro = true;
        }
        if (isAggro)
        {
            AggroBehavior();
        }
    }

    public void AggroBehavior()
    {
        animator.SetTrigger("crawling");
        agent.speed = animator.velocity.magnitude;
        Seek(player.transform.position);
    }
    void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, aggroRadius);
    }
}
