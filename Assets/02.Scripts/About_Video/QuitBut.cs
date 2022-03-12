using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class QuitBut : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    private bool isQuit = false;
    public VideoPlayer my_video;
    public TMP_Text notice;
    [SerializeField]
    private GameObject canvas;
    void Start()
    {
        canvas.SetActive(false);
        notice.color = new Color32(255,255,255,255);
    }
    void Update()
    {
        StartCoroutine(Skip());
    }
    IEnumerator Skip()
    {
        if(!isQuit)
        {
            if (OVRInput.GetDown(OVRInput.Button.Two,leftController))
            {
                canvas.SetActive(true);
                my_video.Pause();
                notice.text = "Do you want to Quit? \n y : Left click again \n n : Right click again";
                yield return new WaitForSeconds(2f);
                isQuit = true;
            }
        }
        if(isQuit)
        {
            if (OVRInput.GetDown(OVRInput.Button.Two,leftController))
            {
                canvas.SetActive(false);      
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else  
            Application.Quit();
#endif
            }
            if (OVRInput.GetDown(OVRInput.Button.Two,rightController)) // 스킵 취소
            {
                isQuit = false;
                canvas.SetActive(false);
                my_video.Play();
            }
        }
    }
}
