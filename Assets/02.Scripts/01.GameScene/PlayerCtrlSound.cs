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
    public AudioSource audio4;
    // Start is called before the first frame update
    void Start()
    {
        audio4 = this.gameObject.AddComponent<AudioSource>();
        audio4.playOnAwake = false;
        audio4.loop = false;
    }

    public void PlaySound(string action)
    {
        switch (action)
        {
            case "Jump":
            audio4.clip = BGMList[0].audio;
            break;
            case "Run":
            audio4.clip = BGMList[1].audio;
            break;
        }
        audio4.Play();
    }
}
