using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class DoorBase : MonoBehaviour, ITriggerable
{
    public bool isOpened;

    [SerializeField]
    private AudioSource audioSource;

    void Start()
    {
        isOpened = false;
    }

    public abstract void Trigger();

    protected void PlaySound()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
