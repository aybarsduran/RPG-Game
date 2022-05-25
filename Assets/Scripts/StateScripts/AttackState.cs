using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour 
{

    public bool isAttacking;
    public Animator playerAnimator;
    Animator anim;

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
        Debug.Log("calismiyor");
        
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
        playerAnimator.SetTrigger("GetHit");

        yield return new WaitForSeconds(4f);
        isAttacking= false;

    }

}
