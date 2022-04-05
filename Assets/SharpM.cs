using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharpM : MonoBehaviour
{
    public int Points = 60;
    public Button Clickbutton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("shield"))
        {
            Points -= 20;
            if (Points <= 0)
            {
                GameObject objec = GameObject.FindGameObjectWithTag("shield");
                objec.SetActive(false);
                Clickbutton.interactable = false;

            }
        }
       
    }
}
