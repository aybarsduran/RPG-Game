using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkLook : MonoBehaviour
{
    Animator anim;
    Camera mainCam;

    private float weight = 1.0f;
    void Start()
    {
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
        
    }

    private void OnAnimatorIK()
    {

        anim.SetLookAtWeight(weight,.5f, 1.2f, .5f,.5f);
        Ray lookAtRay= new Ray(transform.position, mainCam.transform.forward);//baþlangýç ve yönelimi

        anim.SetLookAtPosition(lookAtRay.GetPoint(25)); ;
        
    }

    public void IKlookAcma()
    {
        weight = Mathf.Lerp(weight, 1f, Time.fixedDeltaTime);
    }
    public void IKlookKapatma()
    {
        weight = Mathf.Lerp(weight,0f, Time.fixedDeltaTime);
    }
}
