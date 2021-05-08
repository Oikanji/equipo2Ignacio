using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changescene1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag ("Finish"))
        {
            PortalScene(); 
        }
    }

    public void PortalScene()
    {
        
        SceneManager.LoadScene("Pantalla_Final");

    }
}