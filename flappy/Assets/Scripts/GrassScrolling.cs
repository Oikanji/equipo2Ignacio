using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassScrolling : MonoBehaviour
{
    public Renderer grass;

    public float velocity;

    private void Update()
    {
        if (!GameManager.deadPlayer)
        {
            grass.material.mainTextureOffset = grass.material.mainTextureOffset + new Vector2(velocity, 0) * Time.deltaTime;
        }
    }

}
