using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeBar : MonoBehaviour
{
    public int life = 3;

    private void Start()
    {
        
    }


    void Update()
    {
        if (life <= 0)
        {
            GameOver.show();
        }
    }

    
}
