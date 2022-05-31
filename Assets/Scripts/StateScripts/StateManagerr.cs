using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerr : MonoBehaviour
{
    public AttackState attackState;
    public IdleState idleState;
    public ChaseState chaseState;
    public PatrolState patrolState;
    public LandState landState;
    


    public float distanceToPlayer;
    public float triggerRange = 25f;
    public float attackRange = 8f;
    public Transform Player;

    public bool battleStarted;
    public bool isFlying;
   
    void Start()
    {
        patrolState.enabled = true;
    }

    
    void Update()
    {
        if(transform.position.y > 0.55f)
        {
            isFlying = true;
        }
        else
        {
            isFlying = false;
        }
        distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (distanceToPlayer < triggerRange && battleStarted==false && !isFlying)//Chase
        {
            chaseState.enabled = true;
            idleState.enabled = false;
            attackState.enabled = false;
            patrolState.enabled=false;
            landState.enabled = false;

        }

        if ( distanceToPlayer < attackRange)//Attack
        {
            attackState.enabled = true;
            chaseState.enabled = false;
            idleState.enabled=false;
            patrolState.enabled = false;
            battleStarted = true;
            landState.enabled = false;


        }
        if ( distanceToPlayer > triggerRange && !isFlying)//Idle
        {
            attackState.enabled = false;
            chaseState.enabled=false;
            patrolState.enabled = false;
            idleState.enabled = true;
            landState.enabled = false;

        }
        if(distanceToPlayer <120f && isFlying)//LandState
        {
            patrolState.enabled = false;
            attackState.enabled = false;
            chaseState.enabled = false;
            idleState.enabled = false;
            landState.enabled = true;

        }

        if ( distanceToPlayer > attackRange && distanceToPlayer < triggerRange)//Chase if we try to escape from battle.
        {
            patrolState.enabled = false;
            chaseState.enabled = true;
            attackState.enabled=false;
            idleState.enabled = false;
            landState.enabled = false;


        }

        
    }
}
