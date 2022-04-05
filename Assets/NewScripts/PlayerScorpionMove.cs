using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScorpionMove : MonoBehaviour
{
  
    // Start is called before the first frame update
    private GameObject SearchObj;
    public Transform Enemy;
 
    public float speed = 10f;
    public float Jumpspeed = 10f;
    public float MovementX;
    private Rigidbody2D rb;
    private Animator anim;
    private string WalkAnimation = "Walk";
    private bool isGrounded;
    //public Transform attackpoint;
    //public float AttackRange = 0.6f;
    //public LayerMask EnemyLayer;
    public float AttackRate = 2f;
    float NextAttackTime = 0f;
    //public int AttackDamage = 10;
    //public float Ispeed;
    public Buttons LB;
    public RightButton RB;
    public bool isAttacking = false;


    // Start is called before the first frame update
    void Start()
    {
        //GameObject SearchObj = GameObject.Find("Shield");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Animateplayer();
        playerjump();
        if (Time.time >= NextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Attack();
                NextAttackTime = Time.time + 1f / AttackRate;
            }
        }
        if (isGrounded == false)
        {
            anim.SetBool(WalkAnimation, false);
        }

    }
    private void FixedUpdate()
    {
          
    }

    void MovePlayer()
    {
        MovementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(MovementX, 0f, 0f) * speed * Time.deltaTime;

    }
    void Animateplayer()
    {
        if (MovementX > 0 || RB._pressed)
        {
            anim.SetBool(WalkAnimation, true);
            transform.eulerAngles = new Vector2(0, 0);

        }
        else if (MovementX < 0 || LB._pressed)
        {
            anim.SetBool(WalkAnimation, true);
            transform.eulerAngles = new Vector2(0, 180);

        }
        else
        {
            anim.SetBool(WalkAnimation, false);
        }

    }
    public void playerjump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0, 1) * Jumpspeed, ForceMode2D.Impulse);

        }

    }
    public void Scorpionjump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0, 1) * Jumpspeed, ForceMode2D.Impulse);

        }

    }

    public void Attack()
    {
        if (isAttacking == false) {
            isAttacking = true;
            anim.SetTrigger("Attack");
            StartCoroutine("Attacked");
        }
           

    }
    public void KickAttack()
    {

        if (isAttacking == false)
        {
            isAttacking = true;
            anim.SetTrigger("KickAttack");
            StartCoroutine("Attacked");
        }
  
    }
    public void FireAttack()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            anim.SetTrigger("FireAttack");
            StartCoroutine("Attacked");
        }

      

    }
    public void ArrowStrike()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            anim.SetTrigger("ArrowStrike");
            StartCoroutine("Attacked");
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundTag"))
        {
            isGrounded = true;
        }

    }
    //private void OnDrawGizmosSelected()
    //{
    //    if (attackpoint == null)
    //    {
    //        return;
    //    }

    //    Gizmos.DrawWireSphere(attackpoint.position, AttackRange);
    //}
    IEnumerator Attacked()
    {
        yield return new WaitForSeconds(0.8f);
        isAttacking = false;

    }

    public void OnpressedDown()
    {

        SearchObj.SetActive(true);    

    }
    public void Onpressedup()
    {
        SearchObj.SetActive(false);
    }

}