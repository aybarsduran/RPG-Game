using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonoBehaviour 
{
   
    Animator anim;

 
    private void Start()
    {
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        anim.SetFloat("speed", 0);
    }


}
