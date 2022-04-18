using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour
{
    private float Timebtwmspawn;
    public float StartTimeBetweenspawn;
    public GameObject echo;
    private MovePlayer Playermove;
    // Start is called before the first frame update
    void Start()
    {
        Playermove = GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Playermove.MovementX !=0)
        {
            if (Timebtwmspawn < 0)
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
    }
}
