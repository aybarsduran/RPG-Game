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

    private void OnAnimatorIK(int layerIndex)
    {

        anim.SetLookAtWeight(.6f, .2f, 1.2f);
        Ray lookAtRay= new Ray(transform.position, mainCam.transform.forward);//baþlangýç ve yönelimi

        anim.SetLookAtPosition(lookAtRay.GetPoint(25)); ;
        
    }
}
