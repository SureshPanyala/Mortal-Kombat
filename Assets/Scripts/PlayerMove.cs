using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private GameObject SearchObj;
    public Transform Gun;
    public GameObject Bullets;
    public float speed = 10f;
    public float Jumpspeed = 10f;
    public float MovementX;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;
    private string WalkAnimation = "Walk";
    private bool isGrounded;
    public Transform attackpoint;
    public float AttackRange = 0.6f;
    public LayerMask EnemyLayer;
    public float AttackRate = 2f;
    float NextAttackTime = 0f;
    public int AttackDamage = 10;
    int CurrentWeaponNo;
    public float Ispeed;
    public Buttons LB;
    public RightButton RB;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject SearchObj = GameObject.Find("Shield");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
   
    }

    // Update is called once per frame
    void Update()
    {

        //shield();
     
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeWeapon();
        }
        if (Input.GetKeyDown(KeyCode.S) && CurrentWeaponNo == 1)
        {
            //GunShot();
        }
        MovePlayer();
        Animateplayer();
        playerjump();
        if (Time.time >= NextAttackTime)
        {
            if (Input.GetMouseButtonDown(1))
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
        if (MovementX > 0  || RB._pressed )
        {
            anim.SetBool(WalkAnimation, true);
            transform.eulerAngles = new Vector2(0, 180);
          
        }
        else if (MovementX < 0  || LB._pressed)
        {
            anim.SetBool(WalkAnimation, true);
            transform.eulerAngles = new Vector2(0, 0);
         
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
    public void Pjump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0, 1) * Jumpspeed, ForceMode2D.Impulse);


        }

    }


    public void Attack()
    {
        anim.SetTrigger("Attack");
        
        
        //Collider2D[] HitEnemy = Physics2D.OverlapCircleAll(attackpoint.position, AttackRange, EnemyLayer);

        //foreach (Collider2D enemy in HitEnemy)
        //{
        //    //enemy.GetComponent<HealthEnemy>().TakeDamage(AttackDamage);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundTag"))
        {
            isGrounded = true;
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackpoint.position, AttackRange);
    }
    public void ChangeWeapon()
    {

        if (CurrentWeaponNo == 0)
        {

            CurrentWeaponNo += 1;
            anim.SetLayerWeight(CurrentWeaponNo - 1, 0);
            anim.SetLayerWeight(CurrentWeaponNo, 1);
        }
        else
        {
            CurrentWeaponNo -= 1;
            anim.SetLayerWeight(CurrentWeaponNo + 1, 0);
            anim.SetLayerWeight(CurrentWeaponNo, 1);
        }
        
    }
  
    public void OnpressedDown()
    {

        SearchObj.SetActive(true);


    }
    public void Onpressedup()
    {
        SearchObj.SetActive(false);
    }


    //Android using buttons
   

    public void onAttack()
    {
        anim.SetTrigger("Attack");
    }
    //public void animate()
    //{
    //    anim.SetBool(WalkAnimation, true);
    //}
   


}