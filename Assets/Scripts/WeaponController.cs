using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    bool isSrafe =false;
    Animator anim;

    public GameObject handWeapon;
    public GameObject spineWeapon;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("iS", isSrafe);


        if (Input.GetKeyDown(KeyCode.Tab)){
            isSrafe = !isSrafe;
        }

        if (isSrafe == true) {

            GetComponent<Controller>().MovementT = Controller.MovementType.Strafe;//true ise hareket tipimiz strafe
        }
        if (isSrafe == false)
        {

            GetComponent<Controller>().MovementT = Controller.MovementType.Directional;//true ise hareket tipimiz directional
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
