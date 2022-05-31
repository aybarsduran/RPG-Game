using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonoBehaviour
{

    Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();

    }
    private void Update()
    {

      
            anim.SetFloat("distanceFromGround", 7);

            transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 90f * Time.deltaTime * 0.1f);


        
        
    }


}
