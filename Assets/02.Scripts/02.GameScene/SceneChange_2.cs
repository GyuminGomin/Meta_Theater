using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SceneChange_2 : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    public AudioClip AudioItem;
    private AudioSource audio5;

    void Start()
    {
        this.audio5 = this.gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "MISSION1")
        {
            canvas = GameObject.Find("Canvas_col1");
            canvas.SetActive(false);
            PlaySound("ITEM");
        }
        if(col.tag == "MISSION2")
        {
            canvas = GameObject.Find("Canvas_col2");
            canvas.SetActive(false);
            PlaySound("ITEM");
        }
        if(col.tag == "MISSION3")
        {
            canvas = GameObject.Find("Canvas_col3");
            canvas.SetActive(false);
            PlaySound("ITEM");
        }
        if(col.tag == "MISSION4")
        {
            canvas = GameObject.Find("Canvas_col4");
            canvas.SetActive(false);
            PlaySound("ITEM");
        }
    }
    void PlaySound(string action)
    {
        switch (action) {
            case "ITEM" :
                audio5.clip = AudioItem;
                break;
        }
        audio5.Play();
    }
}
