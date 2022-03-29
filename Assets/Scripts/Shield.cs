using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject ShieldObj;
    public bool ShieldOn;
    public Enemymove EM;

    // Start is called before the first frame update
    void Start()
    {
        ShieldOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        //float Xin = GetComponent<PlayerMove>().MovementX;
       

    }
    public void OnpressedDown()
    {
        ShieldObj.SetActive(true);
        ShieldOn = true;


    }
    public void Onpressedup()
    {
        ShieldObj.SetActive(false);
        ShieldOn = false;
    }
   


}
