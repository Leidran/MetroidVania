using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeBar : MonoBehaviour
{
    public Image LifeBar;

    public float actualLife;

    public float maximumLife;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            damage(1);
        }
    }

    public void damage(float damage)
    {
        actualLife = actualLife - damage;
        LifeBar.fillAmount = actualLife / maximumLife;
    }
}
