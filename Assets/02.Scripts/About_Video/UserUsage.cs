using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class UserUsage : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    private bool isClick = false;
    private int page = 0; // 설명서 페이지
    public VideoPlayer my_video;
    public TMP_Text notice; // 1
    public TMP_Text notice2; // 3
    public TMP_Text notice3; // 4
    public TMP_Text notice4; // 5
    [SerializeField]
    private GameObject canvas; // 1번째 page
    [SerializeField]
    private GameObject canvas_2; // 2번째 page --> 인덱스 트리거 버튼 설명
    [SerializeField]
    private GameObject canvas_3; // 3번쨰 page --> Button one 설명
    [SerializeField]
    private GameObject canvas_4; // 4번째 page --> Button two 설명

    void Start()
    {
        canvas.SetActive(false);
        canvas_2.SetActive(false);
        canvas_3.SetActive(false);
        canvas_4.SetActive(false);
    }

    void Update()
    {
        StartCoroutine(User());
    }
    IEnumerator User()
    {
        if(!isClick && page == 0)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger,leftController)) // 1페이지로 가기
            {
                page += 1;
                canvas.SetActive(true); // 1
                my_video.Pause();
                notice.text = "This is manual, \n You can read and use it. \n Click button again";
                yield return new WaitForSeconds(0.5f);
                isClick = true;
            }
        }
        if(page == 1)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger,leftController)) // 2페이지로 가기
            {
                canvas.SetActive(false);
                canvas_2.SetActive(true);
                notice2.text = "Trigger Click = Muted Btn \n If you want to mute, \n You just click Trigger Btn";
                yield return new WaitForSeconds(0.5f);
                page += 1; // 현재 page 2
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger,rightController)) // 다시 비디오 시작
            {
                canvas.SetActive(false);
                my_video.Play();
                yield return new WaitForSeconds(0.5f);
                isClick = false;
                page -= 1; // 현재 page 0
            }
        }
        if(page == 2)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger,leftController)) // 3페이지로 가기
            {
                canvas_2.SetActive(false);
                canvas_3.SetActive(true);
                notice3.text = "Left Btn.One = Skip Btn \n Right Btn.One = Cancle Skip Btn";
                yield return new WaitForSeconds(0.5f);
                page += 1; // 현재 page 3
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger,rightController)) // 1페이지로 돌아가기
            {
                canvas_2.SetActive(false);
                canvas.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                page -= 1; // 현재 page 1
            }
        }
        if(page == 3)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger,leftController)) // 4페이지로 가기
            {
                canvas_3.SetActive(false);
                canvas_4.SetActive(true);
                notice4.text = "Left Btn.Two = Quit Btn \n Right Btn.Two = Cancle Quit Btn";
                yield return new WaitForSeconds(0.5f);
                page += 1; // 현재 page 4
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger,rightController)) // 2페이지로 돌아가기
            {
                canvas_3.SetActive(false);
                canvas_2.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                page -= 1; // 현재 page 2
            }
        }
        
        if(page == 4)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger,leftController)) // 설명창 끝
            {
                canvas_4.SetActive(false);
                my_video.Play();
                yield return new WaitForSeconds(0.5f);
                isClick = false;
                page = 0; // 현재 page 0
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger,rightController)) // 3페이지로 돌아가기
            {
                canvas_4.SetActive(false);
                canvas_3.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                page -= 1; // 현재 page 3
            }
        }
    }
}
