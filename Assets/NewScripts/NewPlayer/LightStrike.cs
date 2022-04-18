using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightStrike : MonoBehaviour
{
    public GameObject Enemy;
    public float movespeed = 3f;
    private Animator anim;
    public bool Setpostion = true;
    public bool isstriking = false;
    public Button DoubleAttackbutton;
    public Text cooltime;
    private float Currenttime = 0f;
    private float Startingtime = 10f;
    public bool isLight = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Currenttime = Startingtime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Setpostion == true)
        {
            Vector2 pos = new Vector2(Enemy.transform.position.x, 4.96f);
            transform.position = Vector2.MoveTowards(transform.position, pos, movespeed * Time.deltaTime);
        }
        else if (Setpostion == false)
        {
            transform.position = new Vector3(6.39f, 4.96f, 0f);
        }
        if (DoubleAttackbutton.interactable == false)
        {
            cooltime.text = Currenttime.ToString("0");
            Currenttime -= 1f * Time.deltaTime;
        }
        if (Currenttime <= 0)
        {
            Currenttime = Startingtime;
        }
    }
    public void LightStriked()
    {
        
        //anim.SetTrigger("Light");
        if (isstriking == false && isLight == false)
        {
            isstriking = true;
           
            anim.SetTrigger("Light");
            StartCoroutine("Striked");
              }
    }

    IEnumerator Striked()
    {
        //Healthbutton.enabled = false;
        //cooltime.enabled = true;
        DoubleAttackbutton.interactable = false;
        cooltime.enabled = true;

        yield return new WaitForSeconds(10f);
       
        
        DoubleAttackbutton.interactable = true;
        cooltime.enabled = false;
        isstriking = false;
       

    }


}
