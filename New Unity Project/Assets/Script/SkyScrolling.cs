using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScrolling : MonoBehaviour
{

    public Material fondo;
    public float velocidad;
    public Renderer render;
    public double x;


    void Start()
    {
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 a = new Vector2();

        if (Input.GetKey(KeyCode.D))
        {
            x = x + 0.0001f* velocidad;
            //float offset = (float)x;  
            //a.x = offset;
            //a.y = 0;
            render.material.mainTextureOffset = new Vector2((float)x, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            x = x - 0.0001f * velocidad;
            //float offset = (float)x;
            //a.x = offset;
            //a.y = 0;
            render.material.mainTextureOffset = new Vector2((float)x, 0);
        }
    }

}
