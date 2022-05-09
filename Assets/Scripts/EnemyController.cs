using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator anim;
    public float maxHealth = 100f;
    public float expGranted;
    public float attackDamage;
    
    public float currentHealth;
    public bool dead;
    public Controller player;
    public Transform Player;
    float MoveSpeed = 2f;
    float triggerRange= 25f;
    public bool isFollowing;
    bool attack = false;

    float attackRange = 8f;
    float distancetoPlayer;
    bool isAttacking;
    public Animator animPlayer;






    public void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        isAttacking = false;
        
        
       


    }
    public void Update()
    {

        distancetoPlayer = Vector3.Distance(transform.position, Player.position);
        ChasePlayer();
        Attack();
        StopChasing();
        print(distancetoPlayer);


    }
    public void GetHit(float damage)
    {
      
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            Die();
        }
        

    }
    public void ChasePlayer()
    {
        if (distancetoPlayer <= triggerRange && !isAttacking)
        {
            
            anim.SetFloat("speed", 1);
            transform.LookAt(player.transform);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
     
          
        }
        

    }
    public void StopChasing()
    {
        if (distancetoPlayer >= triggerRange)
        {
            anim.SetFloat("speed", 0);
            isAttacking = false;

        }
    }
    
    public void Die()
    {
        dead = true;
        anim.SetBool("isDead",true);
        DropLoot();
        player.getExperience(expGranted);

    }
    void DropLoot()
    {
        print("A bag of coins");
    }


  
    IEnumerator AttackCooldownForEnemy()
    {
        attack = true;
        anim.SetTrigger("AttackToPlayer");
        animPlayer.SetTrigger("GetHit");

        yield return new WaitForSeconds(5f);
        attack=false;

    }
    void Attack()
    {
        if (distancetoPlayer <= attackRange)
        {
            isAttacking = true;
            StopChasing();
            anim.SetFloat("speed", 0);
            if(!attack)
            StartCoroutine(AttackCooldownForEnemy());


        }
    }



}
