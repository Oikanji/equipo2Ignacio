using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volumen : MonoBehaviour
{
    public float volumenValue = 0.5f;
    public AudioSource levelSound;
    //public AudioSource deathSound;
    //public AudioSource winSound;
    static public bool level = true;
    //static public bool death = false;
    //static public bool win = false;
    private float low = 0.2f;
    private float high = 1.0f;


    void Awake()
    {
        levelSound = GetComponent<AudioSource>();
    }

    void OnGUI()
    {

        
            volumenValue = GUI.HorizontalSlider(new Rect(25, 75, 100, 30), volumenValue, low, high);
            levelSound.volume = volumenValue;
        
    }

    public void LevelSound()
    {

            level = true;
         //   death = false;
            levelSound.Play();
        
    }

    //public void DeathSound()
    //{

    //        if (levelSound.isPlaying)
    //            level = false;
    //        {
    //            levelSound.Stop();
    //        }
    //        if (!deathSound.isPlaying && death == false)
    //        {
    //            deathSound.Play();
    //            death = true;
    //        }
        
    //}

    //public void WinSound()
    //{
    //    if (!Movimiento.gameOver)
    //    {
    //       if (levelSound.isPlaying)
    //         level = false;
    //       {
    //           levelSound.Stop();
    //       }

    //       if (!winSound.isPlaying && win == false)
    //       {
    //           winSound.Play();
    //           win = true;
    //           Movimiento.gameWin = true;
    //       }
    //    }
    //}
}