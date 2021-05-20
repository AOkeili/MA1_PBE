using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    Sound[] sounds;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string audioName)
    {
       Sound s = Array.Find(sounds, sound => sound.name == audioName);
        if(s != null)
        {
            s.source.Play();
        }
    }

    public void Stop(string audioName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == audioName);
        if (s != null)
        {
            s.source.Stop();
        }
    }
}
