using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    bool isStrafe = false;
    
    Animator anim;
    public SFXManager SFXmanager;

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
        getInput();
        CloseOrOpenStrafe();
        
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
             
        void getInput()
        {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isStrafe == true && canAttack == true)
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Q) && isStrafe == true && canAttack == true)
        {
            Spell();    
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && isStrafe == true && canAttack == true)
        {
            Block();
        }

        if (Input.GetKeyUp(KeyCode.Mouse1) && isStrafe == true)
        {
            ReleaseBlock(); 
        }

    }

    void Attack()
    {
        isAttack = true;
        
        anim.SetTrigger("Attack");
        SFXmanager.PlaySwordHit();
       
        
    }
    void Spell()
    {
        isAttack = true;
        anim.SetTrigger("SpellCast");
    }

    void Block()
    {
        anim.SetTrigger("Block");
    }
    void ReleaseBlock()
    {
        anim.SetTrigger("ReleaseBlock");
    }
    public void CloseOrOpenStrafe()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && anim.GetBool("isAttack") == false)
        {
            SFXmanager.PlayPullSword();
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

    }


   
   
    }

