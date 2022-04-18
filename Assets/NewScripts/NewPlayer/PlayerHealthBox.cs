using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBox : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    //private int damage = 20;
    //public Healthh healthscript;
    //public HBScript HBS;
    public ShieldM SHM;
    public GameObject particle;
    public Transform ParticleTransform;
    public UIManager Ui;
    public Button Healthbutton;
    private Animator anim;
    private SpriteRenderer Spr;
    //private Rigidbody2D rb;
    //public Button[] buttonon;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        Spr= GetComponent<SpriteRenderer>();

        //healthscript.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            //anim.SetTrigger("Fallen");
            //GetComponent<Collider2D>().enabled = false;
            anim.SetBool("Dead",true);
            anim.SetTrigger("dead");
            Spr.color = new Color(1f, 1f, 1f, .5f);
            StartCoroutine("PlayerAct");
            //gameObject.SetActive(false);

            Ui.GameOver();
            
            //foreach(Button x in buttonon)
            //{
            //    x.interactable = false;
            //}
        }
      

    }
   
    public void TakeDamage(int damage)
    {

        if (SHM.ShieldOn == false)
        {
            currentHealth -= damage;
            Instantiate(particle, ParticleTransform.position, Quaternion.identity);
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
    IEnumerator PlayerAct()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<Collider2D>().enabled = false;
        gameObject.SetActive(false);
    }

}