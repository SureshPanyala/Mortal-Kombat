using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Consumabletopdown : MonoBehaviour
{
    public Animator anim;
    //Transform[] Children;
    public GameObject World;
    public int count;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        count = World.transform.childCount;
    }

    // Update is called once per frame
    public void buttonpress()
    {
        //count = World.transform.childCount;
        switch (count)
        {
            case 1:
                anim.SetTrigger("consumable1");
                break;
            case 2:
                anim.SetTrigger("consumable2");
                break;
            case 3:
                anim.SetTrigger("consumable3");
                break;
            case 4:
                anim.SetTrigger("consumable4");
                break;
            case 5:
                anim.SetTrigger("consumable5");
                break;
            case 6:
                anim.SetTrigger("consumable");
                break;
            default:
                anim.SetTrigger("consumable");
                break;

        }

    }
  




}
