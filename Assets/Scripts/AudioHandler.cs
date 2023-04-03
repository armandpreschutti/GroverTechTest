using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioHandler : MonoBehaviour
{
    public AudioClip openChestSFX;
    public AudioClip closeChestSFX;
    public AudioClip startGameSFX;

    private AudioSource audioSource;

    /// <summary>
    /// On start, this function sets all the needed components for gameplay to a variable.
    /// </summary>
    private void Start()
    {
        audioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    /// <summary>
    /// When called, this function plays an upbeat SFX.
    /// </summary>
    public void PlayChestOpenSFX()
    {
        audioSource.clip= openChestSFX;
        audioSource.Play();
    }

    /// <summary>
    /// When called, this function plays an downbeat SFX.
    /// </summary>
    public void PlayChestCloseSFX()
    {
        audioSource.clip = closeChestSFX;
        audioSource.Play();
    }
    
    /// <summary>
    /// when called, this function plays the start game SFX.
    /// </summary>
    public void PlayStartGameSFX()
    {
        audioSource.clip = startGameSFX;
        audioSource.Play();
    }
}
