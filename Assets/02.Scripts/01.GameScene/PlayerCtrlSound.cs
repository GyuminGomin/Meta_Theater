using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerCtrlSound : MonoBehaviour
{   
    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audio;
    }

    public BgmType[] BGMList;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = this.gameObject.AddComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.loop = false;
    }

    public void PlaySound(string action)
    {
        switch (action)
        {
            case "Jump":
            audio.clip = BGMList[0].audio;
            break;
            case "Run":
            audio.clip = BGMList[1].audio;
            break;
        }
        audio.Play();
    }
}
