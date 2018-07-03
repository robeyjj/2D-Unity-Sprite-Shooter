using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{

    public AudioSource MusicToPlay;
    // Use this for initialization
    void Start()
    {
        if (!MusicToPlay.isPlaying)
        {
            MusicToPlay.Play();
        }
        if (AudioListener.pause)
        {
            AudioListener.pause = false;
        }
        if (!MusicToPlay.loop)
        {
            MusicToPlay.loop = true;
        }
    }
    void Update()
    {
        if (!MusicToPlay.isPlaying)
        {
            MusicToPlay.Play();
        }
    }
}
