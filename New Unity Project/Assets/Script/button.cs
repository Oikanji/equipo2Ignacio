using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu_Inicio");
    }
    public void LevelButton()
    {
        SceneManager.LoadScene("Sunset_Day");
    }
}
