using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    // audio source
    [SerializeField] AudioSource audioSource;
    // audio clip
    [SerializeField] AudioClip audioClipType;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // play sound
    public void PlaySound()
    {
        audioSource.PlayOneShot(audioClipType);
    }
}
