using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using TMPro;

public class SkipBut : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    private VideoPlayer my_video;
    public bool isSkip = false;
    public TMP_Text notice; // skip 알림창
    [SerializeField]
    private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        my_video = this.gameObject.GetComponent<QuitBut>().my_video;
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
                yield return new WaitForSeconds(0.1f);
                isSkip = true;
            }
        }
        if(isSkip)
        {
            if (OVRInput.GetDown(OVRInput.Button.One,leftController))
            {
                canvas.SetActive(false);
                SceneManager.LoadScene(1);
            }
            if (OVRInput.GetDown(OVRInput.Button.One,rightController)) // 스킵 취소
            {
                isSkip = false;
                canvas.SetActive(false);
                yield return new WaitForSeconds(0.2f);
                my_video.Play();
            }
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger,leftController))
        {
            canvas.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            isSkip = false;
        }
    }
}
