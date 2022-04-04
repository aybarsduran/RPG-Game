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
    float MoveSpeed = 1f;
    float range= 5f;




    public void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        
    }
    public void Update()
    {

        
        ChasePlayer();  
        

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
        if (Vector3.Distance(transform.position, Player.position) >= range)
        {
            anim.SetFloat("speed", 1);
            transform.LookAt(player.transform);

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

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

    
   
    IEnumerator isAttackFalse()
    {
       
        yield return new WaitForSeconds(1f);


    }



}
