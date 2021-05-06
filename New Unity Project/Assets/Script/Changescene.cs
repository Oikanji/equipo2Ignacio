using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changescene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag ("portal"))
        {
            PortalScene(); 
        }
    }

    public void PortalScene()
    {
        SceneManager.LoadScene("NightScene");

    }
}