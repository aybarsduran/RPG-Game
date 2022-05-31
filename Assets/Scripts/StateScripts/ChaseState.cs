using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour
{
  
   
    Animator animator;
    public Transform Player;
    

    public float moveSpeed = 3f;
    public float distanceToPlayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, Player.position);
        

            animator.SetFloat("speed", 1);
            transform.LookAt(Player.transform);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

       
    }

}
