using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class QuitBut : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    public bool isQuit = false;
    public VideoPlayer my_video;
    public TMP_Text notice;
    [SerializeField]
    private GameObject canvas;
    void Start()
    {
        canvas.SetActive(false);
    }
    void Update()
    {
        StartCoroutine(Quit());
    }
    IEnumerator Quit()
    {
        if(!isQuit)
        {
            if (OVRInput.GetDown(OVRInput.Button.Two,leftController))
            {
                canvas.SetActive(true);
                my_video.Pause();
                notice.text = "Do you want to Quit? \n y : Left click again \n n : Right click again";
                yield return new WaitForSeconds(0.2f);
                isQuit = true;
            }
        }
        if(isQuit)
        {
            if (OVRInput.GetDown(OVRInput.Button.Two,leftController))
            {
                canvas.SetActive(false);      
                Application.Quit();
            }
            if (OVRInput.GetDown(OVRInput.Button.Two,rightController)) // 나가기 취소
            {
                isQuit = false;
                canvas.SetActive(false);
                yield return new WaitForSeconds(0.2f);
                my_video.Play();
            }
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger,leftController))
        {
            canvas.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            isQuit = false;
        }
    }
}
