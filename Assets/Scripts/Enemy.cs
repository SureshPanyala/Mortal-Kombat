using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Healthh healthhScript;
    public int maxhealth = 100;
    public int CurrentHealth;
   
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxhealth;
        healthhScript.SetMaxHealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;
        healthhScript.SetHealth(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        print("Die");
        Destroy(gameObject);
     
    }
}
