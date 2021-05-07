using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject panel;
    private void Update()
    {
        if (GameManager.deadPlayer)
        {
            panel.SetActive(true);
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("FlappyBird");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Awake()
    {
        GameManager.deadPlayer = false;
        GameManager.win = false;
    }
}
