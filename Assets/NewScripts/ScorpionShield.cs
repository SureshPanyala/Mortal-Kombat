using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorpionShield : MonoBehaviour
{
    public GameObject ShieldObj;
    public bool ShieldOn;
    public EnemyScorpionMove ESM;
    //public ButtonTest BT;

    // Start is called before the first frame update
    void Start()
    {
        ShieldOn = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnpressedDown()
    {
        ShieldObj.SetActive(true);
        ShieldOn = true;
        StartCoroutine("Shield");       
    }
    //public void Onpressedup()
    //{
    //    ShieldObj.SetActive(false);
    //    ShieldOn = false;
    //    BT.Score -= 1;
    //}
    IEnumerator Shield()
    {
        yield return new WaitForSeconds(2f);
        ShieldObj.SetActive(false);
        //BT.Score -= 1;
        ShieldOn = false;

    }


}