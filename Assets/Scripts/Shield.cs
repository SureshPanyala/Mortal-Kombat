using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject ShieldObj;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float Xin = GetComponent<PlayerMove>().MovementX;
    
    }
    public void OnpressedDown()
    {
       ShieldObj.SetActive(true);
        
    }
    public void Onpressedup()
    {
        ShieldObj.SetActive(false);
    }
}
