using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkLook : MonoBehaviour
{
    Animator anim;
    Camera mainCam;
    void Start()
    {
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
        
    }

    private void OnAnimatorIK()
    {

        anim.SetLookAtWeight(.6f, .2f, 5f);
        Ray lookAtRay= new Ray(transform.position, mainCam.transform.forward);//baþlangýç ve yönelimi

        anim.SetLookAtPosition(lookAtRay.GetPoint(25)); ;
        
    }
}
