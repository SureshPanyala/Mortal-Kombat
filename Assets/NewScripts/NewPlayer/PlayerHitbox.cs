using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{

    private int Attackdamage = 10;
    private PlayerHealthBox PHB;
    private Animator anim;
    private MovePlayer MP;
    
    // Start is called before the first frame update
    void Start()
    {
        PHB = GetComponent<PlayerHealthBox>();
        MP = GetComponent<MovePlayer>();
        anim = GetComponent<Animator>();
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
            PHB.TakeDamage(Attackdamage);
       
            print("collide");
            if (MP.Dragonball == false)
            {
                anim.SetTrigger("Hurt");
            }


        }

    }


}
