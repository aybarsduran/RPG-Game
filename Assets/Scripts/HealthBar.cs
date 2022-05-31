using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image image;
    public void SetHealth(float health){
        image.fillAmount = health/1000;
        
    }
    

    

}
