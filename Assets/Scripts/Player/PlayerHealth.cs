using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //singerton instance for this class
    public static PlayerHealth instace;
    [SerializeField] private int currentHealth;
    private int maxHealth = 3;
    private void Awake()
    {
        //inicialize the Singerton
        instace = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        //call updateUI method in UICotroller
        UIController.instance.UpdateUI(CurrentHealth, MaxHealth);
    }

    // Getters and setters for the parameters
    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
    //get damage our player if current health is greader than zero.
    public void DamagePlayer(int damageAmount)
    {
        if (currentHealth <= 0)
        {
            return;
        }

        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        UIController.instance.UpdateUI(CurrentHealth, MaxHealth);

    }
    public void KillPlayer()
    {
        currentHealth = 0;
        Destroy(gameObject);
        UIController.instance.UpdateUI(CurrentHealth, MaxHealth);
    }
    public void restoreHealth(int restoreAmount)
    {
        currentHealth += restoreAmount;
        UIController.instance.UpdateUI(CurrentHealth, MaxHealth);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DamagePlayer(1);
        }
    }
}
