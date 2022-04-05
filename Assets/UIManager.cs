using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button[] buttons;
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
    public void GameOver()
    {
        gameOver = true;
       
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
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
