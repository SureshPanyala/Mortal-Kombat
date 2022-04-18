using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    //public ManageWeapons Weapon;
    public Button[] buttons;
    public Button[] Attackbuttons;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void Weaponchange()
    //{
    //    GameObject tempbtn = EventSystem.current.currentSelectedGameObject;
    //    int tempbtnindex = tempbtn.transform.GetSiblingIndex();
    //    Weapon.ChangeWeapon(tempbtnindex);
    //    print("print");
    //}
    public void GameOver()
    {
        gameOver = true;
       
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
        foreach (Button x in Attackbuttons)
        {
            x.enabled = false;
            //x.interactable = false;
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void play()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
