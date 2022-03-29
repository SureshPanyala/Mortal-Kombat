using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Player;
    //private Rigidbody2D rb;
    //public Animator anim;
    public float speed;
    public bool _pressed = false;
   
    //private string WalkAnimation = "Walk";
    void Start()
    {
       

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
       

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
       
        
    }


    void Update()
    {
        if (_pressed)
        {
            //anim.SetBool(WalkAnimation, true);
            //Player.transform.eulerAngles = new Vector2(0, 180);
            Player.transform.Translate(-speed *Time.deltaTime, 0f, 0f);
            
           
           

        }
        else if (!_pressed)
        {
            //anim.SetBool(WalkAnimation, false);
            Player.transform.Translate(Vector2.zero);

        }
       

        // DO SOMETHING HERE
    }

}