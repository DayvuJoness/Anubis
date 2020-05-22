using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioControll : MonoBehaviour
{
    private AudioSource music;
    public AudioClip[] tracks;
    private AudioMixerGroup mix;

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic();
    }

    void PlayMusic()
    {
        int rand = Random.Range(0, tracks.Length);
        music = GetComponent<AudioSource>();
        music.clip = tracks[rand];
        music.outputAudioMixerGroup = mix;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!music.isPlaying)
        {
            PlayMusic();
        }
    }
}
