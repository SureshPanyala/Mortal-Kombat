using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideEnemy : MonoBehaviour
{
    
    public int Attackdamage = 10;
    private PlayerHealth PH;

    // Start is called before the first frame update
    void Start()
    {
        PH = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //   if (collision.gameObject.CompareTag("EnemyHit"))
    //    {
    //        GetComponent<HealthEnemy>().TakeDamage(Attackdamage);
    //        print("colliding");
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger" + collision.tag);
        if (collision.gameObject.CompareTag("EnemyHit"))
        {

            PH.TakeDamage(Attackdamage);
            print("collide");
        }

    }


}