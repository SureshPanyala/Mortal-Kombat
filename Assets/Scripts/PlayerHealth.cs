using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    //private int damage = 20;
    public Healthh healthscript;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthscript.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        healthscript.SetHealth(currentHealth);
    }
  
}
