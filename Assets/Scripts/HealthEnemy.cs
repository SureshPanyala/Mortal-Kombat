using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
   //private int damage = 20;
    public Healthh healthscript;
    private Animator anim;
    public Shield SHD;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthscript.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    TakeDamage();
        //}
        if (currentHealth == 0)
        {
            anim.SetBool("isDead", true);
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
           
        }
    }
    public void TakeDamage(int damage)
    {
       
        if (SHD.ShieldOn == false)
        {
            currentHealth -= damage;
            healthscript.SetHealth(currentHealth);
            anim.SetTrigger("hurt");
        }

    }
    //private void OnTriggerEnter2D(Collision2D collision)
    //{
    //    print("trigger");
    //}
}