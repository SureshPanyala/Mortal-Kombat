using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyHitbox : MonoBehaviour
{
    private int Attackdamage = 5;
    private NewEnemyHealth NEH;
    private Animator anim;
    public bool LightStriked = false;
   

    //public bool MStriked = false;



    // Start is called before the first frame update
    void Start()
    {
        //Currenttime = Startingtime;
        NEH = GetComponent<NewEnemyHealth>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger" + collision.tag);
        if (collision.gameObject.CompareTag("PlayerHit"))
        {
            NEH.TakeDamage(Attackdamage);
            //Instantiate(particle, PTransform.position, Quaternion.identity);
            print("collide");
            anim.SetTrigger("hurt");  
            print("strike");

        }
        if (collision.gameObject.CompareTag("SkyLight"))
        {
            NEH.TakeDamage(Attackdamage);
            LightStriked = true;
            
            anim.SetTrigger("Hurt");

            StartCoroutine("HAttacked");

        }
        //if (collision.gameObject.CompareTag("MoonLight"))
        //{
        //    NEH.TakeDamage(Attackdamage);
        //    MStriked = true;
        //    anim.SetTrigger("Hurt");
        //    StartCoroutine("HAttacked");
        //}


    }

    IEnumerator HAttacked()
    {
        yield return new WaitForSeconds(3f);
        LightStriked = false;
       
        //MStriked = false;
        //GetComponent<Collider2D>().isTrigger = true;
    }
  




}