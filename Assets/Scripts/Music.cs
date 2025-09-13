using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource backgroundMusic;
    public AudioSource intro;
    void Start()
    {
        intro.Play();     
    }

    // Update is called once per frame
    void Update()
    {
        //if (!music.isPlaying)
        //{
        //    Debug.Log("audio no play");
        //    music.clip = backgroundMusic;
        //    music.Play();
        //}
        if (!intro.isPlaying && !backgroundMusic.isPlaying)
        {
            Debug.Log("playing music");
            backgroundMusic.Play();
        }
    }
}
