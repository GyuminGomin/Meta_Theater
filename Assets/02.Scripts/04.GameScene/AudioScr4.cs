using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScr4 : MonoBehaviour
{
    public AudioClip audioBack;
    AudioSource audioSource;
    void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
    void Start()
    {
        PlaySound("BackGround");
    }

    void PlaySound(string action)
    {
        switch (action)
        {
            case "BackGround":
            audioSource.clip = audioBack;
            break;
        }
        audioSource.Play();
    }
}
