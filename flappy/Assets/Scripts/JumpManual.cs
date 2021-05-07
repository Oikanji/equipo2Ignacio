using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManual : MonoBehaviour
{
    public float JumpForce;

    private float JumpRecorrido;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(0, JumpRecorrido, 0);

            JumpRecorrido += 0.1f;
        }
    }
}
