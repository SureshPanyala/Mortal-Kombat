using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Button[] Buttons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Button1Pressed()
    {


        player1.SetActive(true);

        player2.SetActive(false);

    }
    public void Button2Pressed()
    {

        player1.SetActive(false);

        player2.SetActive(true);

    }

}
