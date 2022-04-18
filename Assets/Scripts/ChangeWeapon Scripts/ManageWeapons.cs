using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageWeapons : MonoBehaviour
{
    public Transform pivotweaponer;
    public Weapons Weapon;
    private int indexpreviousweapon;
    // Start is called before the first frame update
    void Start()
    {
        GameObject defaaultweapon = Weapon.weapons[0];
        Instantiate(defaaultweapon, pivotweaponer);
        indexpreviousweapon = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeWeapon(int Weaponindex)
    {
        if (Weaponindex != indexpreviousweapon)
        {
            Destroy(pivotweaponer.GetChild(0).gameObject);
            GameObject tempweapon = Weapon.weapons[Weaponindex];
            Instantiate(tempweapon, pivotweaponer);
            indexpreviousweapon = Weaponindex;
        }

    }
}