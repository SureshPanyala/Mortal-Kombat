using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject SearchObj;
    public GameObject echo;
    public GameObject SKyLight;
    //public GameObject Greener;
    //private Animator Greenanim;
    //public Transform Enemy;
  

    public float speed = 10f;
    public float Jumpspeed = 10f;
    public float MovementX;
    private Rigidbody2D rb;
    private Animator anim;
    private string WalkAnimation = "walk";
    private bool isGrounded;
    public bool isCollide = false;


    public float AttackRate = 2f;
    float NextAttackTime = 0f;

    public Buttons LB;
    public RightButton RB;
    public bool isAttacking = false;
    public MoveEnemy Enemy;
    private float Timebtwmspawn;
    public float StartTimeBetweenspawn;
    public bool Dragonball = false;
    public LightStrike LS;
   



    // Start is called before the first frame update
    void Start()
    {
        //GameObject SearchObj = GameObject.Find("Shield");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Greenanim = Greener.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovingPlayer();
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

    void MovingPlayer()
    {
        MovementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(MovementX, 0f, 0f) * speed * Time.deltaTime;

    }
    void Animateplayer()
    {
        if (MovementX > 0 || RB._pressed)
        {
            anim.SetBool(WalkAnimation, true);
            // transform.eulerAngles = new Vector2(0, 0);
            this.gameObject.transform.localScale = new Vector3(0.3f,0.3f,0.3f);

            if (Timebtwmspawn <= 0)
            {
                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, 1f);
                Timebtwmspawn = StartTimeBetweenspawn;
            }
            else
            {
                Timebtwmspawn = -Time.deltaTime;
            }

        }
        else if (MovementX < 0 || LB._pressed)
        {
            anim.SetBool(WalkAnimation, true);
            //transform.eulerAngles = new Vector2(0, 180);
            this.gameObject.transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);

            if (Timebtwmspawn <= 0)
            {
                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, 1f);
                Timebtwmspawn = StartTimeBetweenspawn;
            }
            else
            {
                Timebtwmspawn = -Time.deltaTime;
            }

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
        if (isAttacking == false && isGrounded == true) 
        {
            isAttacking = true;
            //anim.SetTrigger("Attack");
            anim.SetTrigger("Double");
            StartCoroutine("Attacked");
        }
        else if (isAttacking == false && isGrounded == false && isCollide == false)
        { 
           isAttacking = true;
           
            anim.SetTrigger("Rotate");
            SKyLight.SetActive(true);
          
            //Greenanim.SetTrigger("SEffect");
            //    anim.SetTrigger("Shutter");

            StartCoroutine("DAttacked");
            StartCoroutine("DTAttacked");
        }


        }
    //public void KickAttack()
    //{

    //    if (isAttacking == false)
    //    {
    //        isAttacking = true;
    //        anim.SetTrigger("KickAttack");
    //        StartCoroutine("Attacked");
    //    }

    //}
    public void FireAttack()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
           
            anim.SetTrigger("FireAttack");
            StartCoroutine("Attacked");
        }
       



    }
    public void DoubleAttack()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
           

            anim.SetTrigger("Double");
            //Enemy.DoubleStrike = true;

            StartCoroutine("Attacked");
        }
    }
    public void DragonAttack()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            Dragonball = true;
            anim.SetTrigger("Dragon");
            StartCoroutine("DAttacked");
           


        }
    }
    public void KickAttack()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            Dragonball = true;
            anim.SetTrigger("KnifeThrow");
            StartCoroutine("DAttacked");



        }
    }
    //public void ArrowStrike()
    //{
    //    if (isAttacking == false)
    //    {
    //        isAttacking = true;
    //        anim.SetTrigger("ArrowStrike");
    //        StartCoroutine("Attacked");
    //    }


    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundTag"))
        {
            isGrounded = true;
            //LS.isLight = false;

        }
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LS.isLight = true;
            isCollide = true;
        }
        //else if (collision.gameObject.tag !="Enemy")
        //{
        //    LS.isLight = false;
        //    isCollide = false;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LS.isLight = false;
            isCollide = false;
        }
    }


    IEnumerator Attacked()
    {
        yield return new WaitForSeconds(0.5f);
        
       
        isAttacking = false;
      
    }
    IEnumerator DAttacked()
    {
        yield return new WaitForSeconds(1.2f);
        //SKyLight.SetActive(false);
        Dragonball = false;

        isAttacking = false;

    }
    IEnumerator DTAttacked()
    {
        yield return new WaitForSeconds(1f);
        SKyLight.SetActive(false);
       
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