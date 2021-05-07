using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScrolling : MonoBehaviour
{
    public Renderer sky;

    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    private void Update()
    {
        if (!GameManager.deadPlayer)
        {
            sky.material.mainTextureOffset = sky.material.mainTextureOffset + new Vector2(velocity, 0) * Time.deltaTime;
        }
    }

}
