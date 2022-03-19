using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audio;
    }

    public BgmType[] BGMList;

    private AudioSource BGM;
    private string NowBGMname = "";
    // Start is called before the first frame update
    void Start()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.loop = true;
        if(BGMList.Length > 0) PlayBGM(BGMList[0].name);
    }

    public void PlayBGM(string name)
    {
        if (NowBGMname.Equals(name)) return;

        for (int i =0; i<BGMList.Length; ++i)
            if (BGMList[i].name.Equals(name))
            {
                BGM.clip = BGMList[i].audio;
                BGM.Play();
                NowBGMname = name;
            }
    }

    /* public string bgmName = "";

    private GameObject PlayerObject;

    void Start()
    {
        PlayerObject = GameObject.Find("astronaut");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "myplayer")
            CamObject.GetComponent<PlayMusicOperator>().PlayBGM(bgmName);
    } */ // 이건 다른 스크립트로 짜서 물체에 부딪히면 노래가 바뀌는 걸로 구현해야지 GameScene1
    // GameScene2 와 GameScene3 과 GameScene4는 용건씨랑 같이 의논해서 토요일날 구성해야겠다
}
