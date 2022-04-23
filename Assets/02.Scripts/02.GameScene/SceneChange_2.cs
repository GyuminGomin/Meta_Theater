using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneChange_2 : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    GameObject canvas_M_clear;
    public AudioClip AudioItem;
    private AudioSource audio5;
    bool M1 = false;
    bool M2 = false;
    bool M3 = false;
    bool M4 = false;

    void Start()
    {
        this.audio5 = this.gameObject.GetComponent<AudioSource>();
        canvas_M_clear = GameObject.Find("Canvas_M_clear");
        canvas_M_clear.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "MISSION1")
        {
            canvas = GameObject.Find("Canvas_col1");
            canvas.SetActive(false);
            PlaySound("ITEM");
            M1 = true;
        }
        if(col.tag == "MISSION2")
        {
            canvas = GameObject.Find("Canvas_col2");
            canvas.SetActive(false);
            PlaySound("ITEM");
            M2 = true;
        }
        if(col.tag == "MISSION3")
        {
            canvas = GameObject.Find("Canvas_col3");
            canvas.SetActive(false);
            PlaySound("ITEM");
            M3 = true;
        }
        if(col.tag == "MISSION4")
        {
            canvas = GameObject.Find("Canvas_col4");
            canvas.SetActive(false);
            PlaySound("ITEM");
            M4 = true;
        }
        if(col.tag == "WALL")
        {
            ChangeScene();
        }
    }

    void FixedUpdate()
    {
        if (M1 == true && M2 == true && M3 == true && M4 == true)
        {
            canvas_M_clear.SetActive(true);
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

    public void ChangeScene() // 이 함수만 호출하면 씬전환가능
    {
        SceneManager.LoadScene(3);
    }
}
