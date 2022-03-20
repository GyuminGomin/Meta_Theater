using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    public string bgmName = "Hope";
    public AudioClip effectAudio;
    private AudioSource audio;

    private GameObject PlayerObject;

    void Start()
    {
        PlayerObject = GameObject.Find("astronaut");
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PLAYER")
            PlayerObject.GetComponent<AudioScript>().PlayBGM(bgmName);
            PlaySound("effSound");
    }
    void PlaySound(string action)
    {
        switch (action)
        {
            case "effSound":
            audio.clip = effectAudio;
            break;
        }
        audio.Play();
    }
}
