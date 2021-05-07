using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(string Menu)
    {
        SceneManager.LoadScene(Menu);
    }
    public void Awake()
    {
        GameManager.deadPlayer = false;
        GameManager.win = false;
    }
}
