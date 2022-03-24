using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using TMPro;

public class SkipBut_F : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    public VideoPlayer my_video;
    private bool isSkip = false;
    public TMP_Text notice; // skip 알림창
    [SerializeField]
    private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        notice.color = new Color32(255,255,255,255);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Skip());
    }
    IEnumerator Skip()
    {
        if(!isSkip)
        {
            if (OVRInput.GetDown(OVRInput.Button.One,leftController))
            {
                canvas.SetActive(true);
                my_video.Pause();
                notice.text = "Do you want to skip? \n y : Left click again \n n : right click again";
                yield return new WaitForSeconds(3f);
                isSkip = true;
            }
        }
        if(isSkip)
        {
            if (OVRInput.GetDown(OVRInput.Button.One,leftController))
            {
                StartCoroutine(End(2f,1f));
            }
            if (OVRInput.GetDown(OVRInput.Button.One,rightController)) // 스킵 취소
            {
                isSkip = false;
                canvas.SetActive(false);
                my_video.Play();
            }
        }

        IEnumerator End(float time, float time1)
        { 
            notice.text = "Thank you for your effort.\n Have a nice day!";
            yield return new WaitForSeconds(time);
            notice.text = "3";
            yield return new WaitForSeconds(time1);
            notice.text = "2";
            yield return new WaitForSeconds(time1);
            notice.text = "1";
            yield return new WaitForSeconds(time1);
            canvas.SetActive(false);
            SceneManager.LoadScene(1);
        }
    }
}
