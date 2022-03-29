using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove : MonoBehaviour
{
    public GameObject player;
    private float dist;
    public float movespeed;
    public float range;
    float move;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spr;
    public LayerMask playerLayer;
    public int Attackdamage = 10;
    public Transform Attackpoint;
    public float attackRange = 1.5f;
    public float AttackRate = 2f;
    bool isAttacking = false;
    //float NextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
       
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        dist = Vector2.Distance(player.transform.position, transform.position);
        move = player.transform.position.x - transform.position.x;
        //print("move" + move);
        if (dist >= range)
        {
            Vector2 pos = new Vector2(player.transform.position.x, -3.530995f);
            transform.position = Vector2.MoveTowards(transform.position, pos, movespeed * Time.deltaTime);
            if (move < 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
                //spr.flipX = true;
            }
            else if (move > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
                //spr.flipX = false;
            }

           
        }
        if (dist <= 1f)
        {

            //if (Time.time >= NextAttackTime)
            //{

            //    EnemyAttack();
            //    NextAttackTime = Time.time + 1f / AttackRate;

            //}
            if (isAttacking == false)
            {
                EnemyAttack();
                //player.GetComponent<PlayerHealth>().TakeDamage(Attackdamage);
                isAttacking = true;
                anim.SetTrigger("Attack");
                StartCoroutine("Attacked");
            }
      
        }

    }
    IEnumerator Attacked()
    {
        yield return new WaitForSeconds(1f);
        isAttacking = false;

    }
    void EnemyAttack()
    {
        //anim.SetTrigger("Attack");


        //Collider2D[] HitPlayer = Physics2D.OverlapCircleAll(Attackpoint.position, attackRange, playerLayer);

        //foreach (Collider2D player in HitPlayer)
        //{
        //   //player.GetComponent<PlayerHealth>().TakeDamage(Attackdamage);
        //    print("player");
        //}
    }
    private void OnDrawGizmosSelected()
    {
        if (Attackpoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(Attackpoint.position, attackRange);
    }
}
