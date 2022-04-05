using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScorpionHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    //private int damage = 20;
    //public Healthh healthscript;
    private Animator anim;
    public ScorpionShield SHD;
    public UIManager Ui;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        //healthscript.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentHealth <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
            Ui.GameOver();
        }
    }
    public void TakeDamage(int damage)
    {
        if (SHD.ShieldOn == false )
        {
            currentHealth -= damage;
            //healthscript.SetHealth(currentHealth);
            
        }

    }
   
}
