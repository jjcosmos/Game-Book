using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource musicAudioSource;
    public static music musicPlayer;
    private float maxVolume = .5f;
    public AudioClip clickClip;
    void Start()
    {
        musicAudioSource = GetComponent<AudioSource>();
        StopAllCoroutines();
        StartCoroutine(FadeIn());
        musicPlayer = this;
    }

    private IEnumerator FadeIn()
    {
        while (musicAudioSource.volume < maxVolume)
        {
            musicAudioSource.volume += Time.deltaTime * .3f;
            yield return null;
        }
    }

    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutAsync());
    }

    private IEnumerator FadeOutAsync()
    {
        while (musicAudioSource.volume > 0)
        {
            musicAudioSource.volume -= Time.deltaTime * .3f;
            yield return null;
        }
    }

    public void SelectSound()
    {
        musicAudioSource.PlayOneShot(clickClip, .3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
