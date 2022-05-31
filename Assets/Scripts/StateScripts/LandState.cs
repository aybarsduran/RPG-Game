using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandState : MonoBehaviour
{
    Animator animator;
    public Transform Player;
    public SFXManager SFXManager;


    public float moveSpeed;
    public float distanceToPlayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        
        transform.LookAt(Player.transform);
        distanceToPlayer = Vector3.Distance(transform.position, Player.position);
        if (transform.position.y > 21f)
        {
            SFXManager.PlayDragonWing();
            
            animator.SetFloat("distanceFromGround", 7);
           
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            


        }
        if (transform.position.y <= 21f)
        {
            
            animator.SetFloat("distanceFromGround", 5);
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,0.55f,transform.position.z),7f * Time.deltaTime);
            
        }


    }
    private void LateUpdate()
    {
        SFXManager.PlayDragonLand();
    }
}
