using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound1[] sounds;
    public static bool play;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound1 s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        if (!GameManager.deadPlayer)
        {   
                Play("Theme");
        }
    }

    private void Update()
    {
        if (GameManager.deadPlayer)
        {
            Stop("Theme");
        }
    }

    public void Play (string name)
    {
        Sound1 s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound1 s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
