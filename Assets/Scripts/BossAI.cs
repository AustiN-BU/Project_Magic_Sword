/*****************************************************************************
// File Name : BossAI.cs
// Author : Austin Nelson
// Creation Date : April 13, 2025
//
// Brief Description : This controls the boss' behavior and works with the NavMesh
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask Ground, Player;

    //Attacks

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;

    public bool playerInSightRange, playerInAttackRange;

    public Animator bossAnim;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        bossAnim = GetComponent<Animator>();


    }

    private void Update()
    {
        //Checks for Sight and Attack Range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }
   
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        //Makes sure the boss doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        if (!alreadyAttacked)
        {

            //The attack Code goes here
            bossAnim.Play("BossAttack");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
