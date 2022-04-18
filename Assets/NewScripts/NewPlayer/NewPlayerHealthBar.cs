using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayerHealthBar : MonoBehaviour
{
    private Image Health;
    public float CurrentHealth;
    public float MaxHealth = 200f;
    //public PlayerScorpionHealth player;
    public PlayerHealthBox player;
    // Start is called before the first frame update
    void Start()
    {
        Health = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = player.currentHealth;
        Health.fillAmount = CurrentHealth / MaxHealth;
    }
}
