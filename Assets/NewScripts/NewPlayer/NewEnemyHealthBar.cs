using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewEnemyHealthBar : MonoBehaviour
{
    private Image Health;
    public float CurrentHealth;
    public float MaxHealth = 200f;
    public NewEnemyHealth Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Health = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Enemy.currentHealth;
        Health.fillAmount = CurrentHealth / MaxHealth;
    }
}
