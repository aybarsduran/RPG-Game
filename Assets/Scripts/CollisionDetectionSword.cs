using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionSword : MonoBehaviour
{
    public WeaponController weapon;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy"&& weapon.isAttack==true)
        {
            other.GetComponent<Animator>().SetTrigger("GetHit");
            weapon.isAttack=false;  

        }
    }
}
