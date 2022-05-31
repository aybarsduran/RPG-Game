using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour 
{

    public bool isAttacking;
    public Animator playerAnimator;
    Animator anim;
    float attackDamage = 100f;
    public Controller player;

    public SFXManager manager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
        isAttacking = false;

    }
    
    private void Update()
    {
        anim.SetFloat("speed", 0);

        Attack();
       
    }
    void Attack()
    {
        
        if (!isAttacking)
        {
            StartCoroutine(AttackToPlayer());
        }
    }
    IEnumerator AttackToPlayer()
    {
        Debug.Log("calisti");
        isAttacking = true;
        anim.SetTrigger("AttackToPlayer");
        manager.PlayDragonAttack();
        playerAnimator.SetTrigger("GetHit");
        player.getDamage(attackDamage);

        yield return new WaitForSeconds(6f);
        isAttacking= false;

    }

}
