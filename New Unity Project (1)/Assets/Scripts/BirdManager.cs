using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.deadPlayer)
        {
            if (collision.transform.CompareTag("Grass"))
            {
                GameManager.deadPlayer = true;
                FindObjectOfType<AudioManager>().Play("PlayerDeath");
                if (GameManager.win)
                {
                    FindObjectOfType<AudioManager>().Play("Win");
                }
            }
        }
    }
}
