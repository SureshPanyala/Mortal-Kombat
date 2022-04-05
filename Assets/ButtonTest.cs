using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    public int Score;
    public Button Clickbutton;
    // Start is called before the first frame update
    void Awake()
    {
        Clickbutton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Score >= 10)
        {
            Clickbutton.gameObject.SetActive(true);
            Clickbutton.GetComponent<Button>().interactable = true;
        }
        else
        {
            Clickbutton.gameObject.SetActive(false);
            Clickbutton.interactable = false;
        }
    }
}
