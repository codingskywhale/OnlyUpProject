using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    AudioSource audioSource;
    public AudioClip defaultClip;
    public AudioClip endingClip;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBGM(defaultClip); // 기본 BGM 재생
    }
    public void PlayBGM(AudioClip clip)
    {
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    public void PlayDefaultBGM()
    {
        PlayBGM(defaultClip);
    }

    public void PlayEndingBGM()
    {
        PlayBGM(endingClip);
    }
}
