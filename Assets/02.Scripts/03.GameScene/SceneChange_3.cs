using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChange_3 : MonoBehaviour
{
    private GameObject sphere_M_clear;
    private GameObject sphere_M1;
    private GameObject sphere_M2;
    private GameObject sphere_M4;
    private GameObject mission3;
    private GameObject mission3_c;
    public TMP_Text notice;
    private GameObject canvas;
    public AudioClip AudioItem;
    public AudioClip AudioFix;
    private AudioSource audio5;
    
    void Awake()
    {
        sphere_M_clear = GameObject.Find("Sphere_M_clear");
        sphere_M1 = GameObject.Find("Sphere_M1");
        sphere_M2 = GameObject.Find("Sphere_M2");
        sphere_M4 = GameObject.Find("Sphere_M4");
        mission3 = GameObject.Find("MISSION3");
        mission3_c = GameObject.Find("MISSION3_c");
        canvas = GameObject.Find("Canvas_Scene");
    }
    void Start()
    {
        sphere_M2.SetActive(false);
        sphere_M4.SetActive(false);
        sphere_M_clear.SetActive(false);
        mission3_c.SetActive(false);
        canvas.SetActive(false);
        this.audio5 = this.gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "MISSION1")
        {
            sphere_M1.SetActive(false);
            sphere_M2.SetActive(true);
            PlaySound("ITEM");
        }
        if(col.tag == "MISSION2")
        {
            sphere_M2.SetActive(false);
            sphere_M4.SetActive(true);
            PlaySound("ITEM");
        }
        
        if(col.tag == "MISSION4")
        {
            sphere_M4.SetActive(false);
            sphere_M_clear.SetActive(true);
            PlaySound("ITEM");
        }
        if(col.tag == "MISSION3")
        {
            mission3.SetActive(false);
            mission3_c.SetActive(true);
            PlaySound("FIX");
        }
        if(col.tag == "WALL")
        {
            StartCoroutine(delayT());
        }
    }

    void PlaySound(string action)
    {
        switch (action) {
            case "ITEM" :
                audio5.clip = AudioItem;
                break;
            case "FIX" :
                audio5.clip = AudioFix;
                break;
        }
        audio5.Play();
    }

    IEnumerator delayT()
    {
        canvas.SetActive(true);

        notice.text = "3";
        yield return new WaitForSeconds(1f);
        notice.text = "2";
        yield return new WaitForSeconds(1f);
        notice.text = "1";
        yield return new WaitForSeconds(1f);
        ChangeScene();
    }

    public void ChangeScene() // 이 함수만 호출하면 씬전환가능
    {
        SceneManager.LoadScene(5);
    }
}
