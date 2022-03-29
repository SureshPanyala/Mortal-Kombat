using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideranim : MonoBehaviour
{
    //public PlayerHealth PH;
    public int Attackdamage = 10;
    private HealthEnemy PH;

    // Start is called before the first frame update
    void Start()
    {
        PH = GetComponent<HealthEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("PlayerHit"))
    //    {
        
    //        PH.TakeDamage(Attackdamage);
    //        print("collide");
    //    }
       
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger"+ collision.tag);
        if (collision.gameObject.CompareTag("PlayerHit"))
        {

            PH.TakeDamage(Attackdamage);
            print("collide");
        }

    }


}
