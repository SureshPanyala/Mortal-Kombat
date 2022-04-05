using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScorpionHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    //private int damage = 20;
    //public Healthh healthscript;
    //public HBScript HBS;
    public ScorpionShield SHD;
    public UIManager Ui;
    public Button Healthbutton;
   

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //healthscript.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            gameObject.SetActive(false);
            Ui.GameOver();
        }
    }
    public void TakeDamage(int damage)
    {

        if (SHD.ShieldOn == false)
        {
            currentHealth -= damage;
            //healthscript.SetHealth(currentHealth);
        }

    }
    public void Healthboost()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 30;
            Healthbutton.enabled = false;
            Healthbutton.interactable = false;
           
        }
        
    }
 
}