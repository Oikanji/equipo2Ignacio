using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBird : MonoBehaviour
{
    public float magnitud;
    void Update()
    {
        if (!GameManager.deadPlayer)
        {
            transform.Translate(0, -magnitud, 0);
        }
    }
}
