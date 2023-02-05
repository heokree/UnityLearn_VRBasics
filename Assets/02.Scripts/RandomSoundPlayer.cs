using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource[] audioSources;
    private AudioSource playingAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponentsInChildren<AudioSource>();
        PlayRandom();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playingAudioSource.isPlaying)
        {
            PlayRandom();
        }
    }

    void PlayRandom()
    {
        var audioSource = audioSources[Random.Range(0, audioSources.Length)];
        var audioClip = clips[Random.Range(0, clips.Length)];

        audioSource.clip = audioClip;
        playingAudioSource = audioSource;
        audioSource.Play();
    }
}
