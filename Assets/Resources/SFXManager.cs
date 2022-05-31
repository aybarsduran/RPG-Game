using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public AudioSource snowWalk;
    public AudioSource swordSound;
    public AudioSource dragonWing;
    public AudioSource dragonLand;
    public AudioSource pullSword;
    public AudioSource swordHit;
    public AudioSource dragonHurt;
    public AudioSource dragonAttack;

    public void PlayBang()
    {
        snowWalk.Play();
    }

    public void PlaySwordSound()
    {
        swordSound.Play();
    }
    public void PlayDragonWing()
    {
        dragonWing.Play();
    }
    public void PlayPullSword()
    {
        pullSword.Play();
    }
    public void PlayDragonLand()
    {
        dragonLand.Play();
    }
    public void PlayDragonHurt()
    {
        dragonHurt.Play();
    }
    public void PlaySwordHit()
    {
        swordHit.Play();
    }
    public void PlayDragonAttack()
    {
        dragonAttack.Play();
    }



}
