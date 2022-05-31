using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    Animator anim;

    public float maxHealth = 1000f;
    public float expGranted;
    public float attackDamage;
    public float currentHealth;

    public bool dead;

    public Controller player;
    public Transform Player;
    

    public float distance;
    Vector3 groundDistance;

    public HealthBar healthBar;

    
    public void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        groundDistance = new Vector3(transform.position.x, 0f, transform.position.z);
        healthBar.SetHealth(maxHealth);
       
       
    }
    public void Update()
    {
        distance = Vector3.Distance(transform.position, groundDistance);
        
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
        healthBar.SetHealth(currentHealth);
       
        if (currentHealth <= 0)
        {
            Die();
        }


    }







}
