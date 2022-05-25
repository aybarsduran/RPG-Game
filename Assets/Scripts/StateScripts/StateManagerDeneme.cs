using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerDeneme : MonoBehaviour
{
    public AttackState attackState;
    public IdleState idleState;
    public ChaseState chaseState;
    


    public float distanceToPlayer;
    public float triggerRange = 25f;
    public float attackRange = 8f;
    public Transform Player;

    public bool battleStarted;
    // Start is called before the first frame update
    void Start()
    {
        idleState.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, Player.position);
        if (distanceToPlayer < triggerRange && battleStarted==false)//Chase
        {
            chaseState.enabled = true;
            idleState.enabled = false;
            attackState.enabled = false;

        }

        if ( distanceToPlayer < attackRange)//Attack
        {
            attackState.enabled = true;
            chaseState.enabled = false;
            idleState.enabled=false;
            battleStarted = true;
            

        }
        if ( distanceToPlayer > triggerRange)//Idle
        {
            attackState.enabled = false;
            chaseState.enabled=false;
            idleState.enabled = true;
            

        }

        if ( distanceToPlayer > attackRange && distanceToPlayer < triggerRange)//Chase if we try to escape from battle.
        {
            chaseState.enabled = true;
            attackState.enabled=false;
            idleState.enabled = false;


        }

        
    }
}
