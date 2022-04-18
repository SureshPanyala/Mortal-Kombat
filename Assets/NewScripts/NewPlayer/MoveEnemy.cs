using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public GameObject player;
    private float dist;
    public float movespeed;
    public float range;
    float move;
    private Animator anim;
    private Rigidbody2D rb;
    //public int Attackdamage = 10;
    //public Transform Attackpoint;
    //public float attackRange = 1.5f;
    //public float AttackRate = 2f;
    public bool isAttacking = false;
    private NewEnemyHitbox NEHB;
    //public bool DoubleStrike = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        NEHB = GetComponent<NewEnemyHitbox>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(player.transform.position, transform.position);
        move = player.transform.position.x - transform.position.x;

        if (dist >= range)
        {
            Vector2 pos = new Vector2(player.transform.position.x, -1.98f);
            if (NEHB.LightStriked == false )
            {
             
                transform.position = Vector2.MoveTowards(transform.position, pos, movespeed * Time.deltaTime);
             
            }
         



            if (move < 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
              


            }
            else if (move > 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
              


            }

     }
        if (dist <= 5f )
        {

            if (isAttacking == false && NEHB.LightStriked == false )
            {

                isAttacking = true;
                anim.SetTrigger("Fireattack");
                StartCoroutine("Attacked");
            }

        }
        //    if (dist <= 3.5f && dist >= 2.5f)
        //    {

        //        if (isAttacking == false)
        //        {

        //            isAttacking = true;
        //            anim.SetTrigger("ArrowStrike");
        //            StartCoroutine("Attacked");
        //        }

        //    }
        //if (dist < 2.5f && dist > 1.5f)
        //{

        //    if (isAttacking == false)
        //    {

        //        isAttacking = true;
        //        anim.SetTrigger("FireAttack");
        //        StartCoroutine("Attacked");
        //    }

        //}
        //    if (dist <= 1.5f && dist >= 1f)
        //    {

        //        if (isAttacking == false)
        //        {

        //            isAttacking = true;
        //            anim.SetTrigger("KickAttack");
        //            StartCoroutine("Attacked");
        //        }

        //    }
        //    if (dist < 1f)
        //    {

        //        if (isAttacking == false)
        //        {
        //            isAttacking = true;
        //            anim.SetTrigger("Attack");
        //            StartCoroutine("Attacked");
        //        }

        //    }
        //if (DoubleStrike == true)
        //{
        //    LightStrike();
        //}

    }
    IEnumerator Attacked()
    {
        yield return new WaitForSeconds(1.6f);
        isAttacking = false;
       

    }
    public void LightStrike()
    {
        anim.SetTrigger("Light");
       
       
    }
 


}