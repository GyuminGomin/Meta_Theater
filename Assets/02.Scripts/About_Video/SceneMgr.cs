using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Scene전환하기 위한 네임스페이스
using UnityEngine.Video;

public class SceneMgr : MonoBehaviour
{
    [SerializeField]
    VideoPlayer video;
    [SerializeField]
    float video_time;
    int pause_speed = 1;
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
// cf로 실무에서는 public을 잘 안사용하고, private를(용어가 기억이 안난다.) 써서 [SerializeField]를 써서 사용 이유 직렬화를 하면, private로 해도 public처럼 뜨기 때문
