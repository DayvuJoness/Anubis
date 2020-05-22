using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShortSoundsController : MonoBehaviour
{
    public PlayerControll player;
    private AudioSource music;
    public AudioClip[] tracks;
    private AudioMixerGroup mix;

    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    //  0 - Земля
    //  1 - Трава
    //  2 - Камень
    //  3 - Песок
    //  4 - Вода
    //  5 - Крылья

    void Update()
    {
        if (!player.isGrounded)
        {
            PlayMusic(5);
        }
        else if (/*player.directionInput != 0 && */player.typeOfPlatform == "dirt" && (player.rb.velocity.x > 0.1 || player.rb.velocity.x < -0.1))
        {
            PlayMusic(0);
        }
        else if (/*player.directionInput != 0 && */player.typeOfPlatform == "grass" && (player.rb.velocity.x > 0.1 || player.rb.velocity.x < -0.1))
        {
            PlayMusic(1);
        }
        else if (/*player.directionInput != 0 && */(player.typeOfPlatform == "rock" || player.typeOfPlatform == "ice") && (player.rb.velocity.x > 0.1 || player.rb.velocity.x < -0.1))
        {
            PlayMusic(2);
        }
        else if (/*player.directionInput != 0 && */player.typeOfPlatform == "sand" && (player.rb.velocity.x > 0.1 || player.rb.velocity.x < -0.1))
        {
            PlayMusic(3);
        }
        else if (/*player.directionInput != 0 && */player.typeOfPlatform == "water" && (player.rb.velocity.x > 0.1 || player.rb.velocity.x < -0.1))
        {
            PlayMusic(4);
        }
        else
        {
            //if (music.clip != tracks[5])
            {
                music.Stop();
            }
        }
    }

    void PlayMusic(int sound)   //звук крыльев
    {
        if (!music.isPlaying)
        {
            music.clip = tracks[sound];
            music.outputAudioMixerGroup = mix;
            music.Play();
        }
    }
}
