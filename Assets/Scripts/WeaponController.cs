using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    bool isStrafe = false;
    Animator anim;
    

    public GameObject handWeapon;
    public GameObject spineWeapon;
    public bool isAttack = false;

    bool canAttack = true;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("iS", isStrafe);


        if (Input.GetKeyDown(KeyCode.Tab) && anim.GetBool("isAttack")==false)
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
            isAttack = true;
            anim.SetTrigger("Attack");
            
        } 
        if (Input.GetKeyDown(KeyCode.Q)&& isStrafe==true && canAttack == true)
        {
            anim.SetTrigger("SpellCast");
        }
        if(Input.GetKeyDown(KeyCode.Mouse1)&& isStrafe==true && canAttack == true)
        {
            anim.SetTrigger("Block");
            
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) && isStrafe == true)
        {
            anim.SetTrigger("ReleaseBlock");
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

