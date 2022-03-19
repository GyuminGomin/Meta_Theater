using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    public string bgmName = "Hope";

    private GameObject PlayerObject;

    void Start()
    {
        PlayerObject = GameObject.Find("astronaut");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PLAYER")
            PlayerObject.GetComponent<AudioScript>().PlayBGM(bgmName);
    } // 이건 다른 스크립트로 짜서 물체에 부딪히면 노래가 바뀌는 걸로 구현해야지 GameScene1
}
