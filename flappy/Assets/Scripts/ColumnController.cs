using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColumnController : MonoBehaviour
{

    public float magnitud;
    public GameObject particulasDead;

    void Update()
    {
        if (!GameManager.deadPlayer)
        {
            transform.Translate(-magnitud, 0, 0);
        }

        if (transform.position.x <-15)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.deadPlayer)
        {
            if (collision.transform.CompareTag("Player"))
            {
                GameManager.deadPlayer = true;
                FindObjectOfType<AudioManager>().Play("PlayerDeath");
                particulasDead.SetActive(true);
                if (GameManager.win)
                {
                    FindObjectOfType<AudioManager>().Play("Win");
                }
            }
        }
    }

}
