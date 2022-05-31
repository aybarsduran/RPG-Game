using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionSword : MonoBehaviour
{
    public WeaponController weapon;
    float weaponDamage = 100;
    public Animator anim;

    public SFXManager manager;
    public GameObject hitParticle;






    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && weapon.isAttack)
        {
            other.GetComponent<Animator>().SetTrigger("GetHit");
            Instantiate(hitParticle, new Vector3(other.transform.position.x+2, other.transform.position.y+6, other.transform.position.z+3), other.transform.rotation);
           manager.PlayDragonHurt();

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
