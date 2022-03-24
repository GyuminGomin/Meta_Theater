using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Scene전환하기 위한 네임스페이스
using UnityEngine.Video;
using TMPro;

public class SceneMgr_F : MonoBehaviour
{
    [SerializeField]
    VideoPlayer video;
    [SerializeField]
    float video_time;
    int pause_speed = 1;
    public TMP_Text notice;
    [SerializeField]
    private GameObject canvas;
    // float current_Time;
    // float pause_Time;
    // bool ispause = true;

    void Start()
    {
        video_time = (float)video.length;
    }
    void Update()
    {
        Pause();
        StartCoroutine(DelayTime(video_time));
    }

    IEnumerator DelayTime(float time)
    {
        yield return new WaitForSeconds(time);
        canvas.SetActive(true);
        notice.text = "Thank you for your effort.\n Have a nice day!";
        yield return new WaitForSeconds(3f);
        notice.text = "3";
        yield return new WaitForSeconds(1f);
        notice.text = "2";
        yield return new WaitForSeconds(1f);
        notice.text = "1";
        yield return new WaitForSeconds(1f);
        canvas.SetActive(false);
        video.Stop();
        ChangeScene();
    }
    public void ChangeScene() // 이 함수만 호출하면 씬전환가능
    {
        SceneManager.LoadScene(1);
        
    }
    void Pause()
    {
        if (video.isPaused)
        {
            video_time += pause_speed*Time.deltaTime;
        }
    }
}