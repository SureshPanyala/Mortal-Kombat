using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    //private int damage = 20;
    //public Healthh healthscript;
    private Animator anim;
    public ShieldM SHM;
    public UIManager Ui;
    public LightStrike LStrike;
    public GameObject particle;
    public Transform PTransform;

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
            LStrike.Setpostion = false;
            anim.SetTrigger("Hurt");
           gameObject.SetActive(false);
            Destroy(gameObject,5f);
            Ui.GameOver();
        }
    }
    public void TakeDamage(int damage)
    {
        if (SHM.ShieldOn == false)
        {
            currentHealth -= damage;
            Instantiate(particle, PTransform.position, Quaternion.identity);
            //healthscript.SetHealth(currentHealth);

        }

    }
  

}