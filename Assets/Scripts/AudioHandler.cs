using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioHandler : MonoBehaviour
{
    public AudioClip openChestSFX;
    public AudioClip closeChestSFX;
    public AudioSource audioSource;

    /// <summary>
    /// When called, this function plays an upbeat SFX
    /// </summary>
    public void PlayChestOpenSFX()
    {
        audioSource.clip= openChestSFX;
        audioSource.Play();
    }

    /// <summary>
    /// When called, this function plays an downbeat SFX
    /// </summary>
    public void PlayChestCloseSFX()
    {
        audioSource.clip = closeChestSFX;
        audioSource.Play();
    }
    
}
