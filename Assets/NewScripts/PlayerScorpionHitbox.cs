using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScorpionHitbox : MonoBehaviour
{

    private int Attackdamage =10;
    private PlayerScorpionHealth PSH;

    // Start is called before the first frame update
    void Start()
    {
        PSH = GetComponent<PlayerScorpionHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger" + collision.tag);
       
        if (collision.gameObject.CompareTag("EnemyHit"))
        {

            PSH.TakeDamage(Attackdamage);
            print("collide");
        }

    }


}