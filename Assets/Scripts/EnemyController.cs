using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator anim;
    public float maxHealth = 100f;
    public float expGranted;
    public float attackDamage;
    public float moveSpeed;
    public float currentHealth;
    public bool dead;
    public Controller player;

    public void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        
    }
    public void Update()
    {
   

    }


    public void GetHit(float damage)
    {
      
        currentHealth -= damage;


        if (currentHealth == 0)
        {
            Die();
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

    IEnumerator RecoverFromHit()
    {
        yield return new WaitForSeconds(0.1f);
        

    }

}
