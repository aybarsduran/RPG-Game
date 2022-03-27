using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    bool isStrafe = false;
    Animator anim;
    int attackIndex;

    public GameObject handWeapon;
    public GameObject spineWeapon;

    bool canAttack = true;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("iS", isStrafe);


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isStrafe = !isStrafe;
        }

        if (isStrafe == true)
        {

            GetComponent<Controller>().MovementT = Controller.MovementType.Strafe;//true ise hareket tipimiz strafe
            GetComponent<IkLook>().IKlookKapatma();
        }
        if (isStrafe == false)
        {

            GetComponent<Controller>().MovementT = Controller.MovementType.Directional;//true ise hareket tipimiz directional
            GetComponent<IkLook>().IKlookAcma();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && isStrafe == true && canAttack == true)
        {
            attackIndex = Random.Range(0, 3);
            anim.SetInteger("attackIndex", attackIndex);
            anim.SetTrigger("Attack");
        } 
        if (Input.GetKeyDown(KeyCode.Q)&& isStrafe==true && canAttack == true)
        {
            anim.SetTrigger("SpellCast");
        }


    }


        void Equip()
        {
            spineWeapon.SetActive(false);
            handWeapon.SetActive(true);
        }

        void Unequip()
        {
            spineWeapon.SetActive(true);
            handWeapon.SetActive(false);

        }
    }

