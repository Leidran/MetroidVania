using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]private Slider healthBar;
    public static UIController instance;
    private void Awake()
    {
        healthBar = FindObjectOfType<Slider>();
    }
    void Start()
    {
        //inicialize this class as a singelton 
        instance= this;
    }
    //this method updates the healthbar
    public void UpdateUI(int currentHealth,int maxHealth)
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }
}
