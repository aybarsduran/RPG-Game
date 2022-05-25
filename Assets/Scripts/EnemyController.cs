using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator anim;
    public Animator animPlayer;

    public float maxHealth = 100f;
    public float expGranted;
    public float attackDamage;
    public float currentHealth;

    public bool dead;

    public Controller player;
    public Transform Player;

    float moveSpeed = 3f;
    float triggerRange = 25f;
    float attackRange = 8f;

    float distanceToPlayer;

    bool isAttacking;


    float randomPatrolRange;
    


    public enum States
    {
        AttackState,
        ChaseState,
        PatrolState,
        
    }
    public States state;



    public void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        isAttacking = false;
        state = States.PatrolState;
        Patrol();

        
        
       


    }
    public void Update()
    {

        distanceToPlayer = Vector3.Distance(transform.position, Player.position);
       // print(distanceToPlayer);
        StateManager();
       

    }
    
    public void ChasePlayer()
    {
        Debug.Log("chasing");
        transform.LookAt(Player.transform);
        anim.SetFloat("speed", 1);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

    }
   
    

    
    void Attack()
    {
        if (distanceToPlayer <= attackRange)
        {


            if (!isAttacking)
                StartCoroutine(AttackToPlayer());


        }

    }
    IEnumerator AttackToPlayer()
    {
        isAttacking = true;
        anim.SetTrigger("AttackToPlayer");
        animPlayer.SetTrigger("GetHit");

        yield return new WaitForSeconds(4f);
        isAttacking = false;

    }
    void Patrol()
    {
        //randomPatrolRange = Random.Range(1, 25);
        //transform.Translate(randomPatrolRange,transform.position.y,randomPatrolRange);
        anim.SetFloat("speed", 0);
    }

    public void StateManager()
    {
        if (state == States.PatrolState && distanceToPlayer < triggerRange)
        {
            ChasePlayer();
            
        }

        if(state == States.ChaseState && distanceToPlayer < attackRange)
        {
            Attack();
           
        }
        if(state == States.ChaseState && distanceToPlayer > triggerRange)
        {
            Patrol();
            
        }

        if(state== States.AttackState && distanceToPlayer > attackRange && distanceToPlayer< triggerRange)
        {
            ChasePlayer();
            
        }

        if(state== States.AttackState && distanceToPlayer > attackRange && distanceToPlayer > triggerRange)
        {
            Patrol();
            
        }
        

    }

    public void Die()
    {
        dead = true;
        anim.SetBool("isDead", true);
        DropLoot();
        player.getExperience(expGranted);

    }
    void DropLoot()
    {
        print("A bag of coins");
    }
    public void GetHit(float damage)
    {

        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            Die();
        }


    }







}
