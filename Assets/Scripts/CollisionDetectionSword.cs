using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionSword : MonoBehaviour
{
    public WeaponController weapon;
    public float weaponDamage=20;
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && weapon.isAttack==true)
        {
            other.GetComponent<Animator>().SetTrigger("GetHit");
            other.GetComponent<EnemyController>().GetHit(weaponDamage);
            weapon.isAttack=false;

          


        }
    }
    IEnumerator isAttackFalse() 
    {
        weapon.isAttack = false;
        yield return new WaitForSeconds(1f);
       

    }

}
