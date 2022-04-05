using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    private int Attackdamage = 10;
    private EnemyScorpionHealth ESH;

    // Start is called before the first frame update
    void Start()
    {
        ESH = GetComponent<EnemyScorpionHealth>();
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
            ESH.TakeDamage(Attackdamage);
            print("collide");
        }

    
    }


}
