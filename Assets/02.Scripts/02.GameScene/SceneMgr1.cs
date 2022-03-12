using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Scene전환하기 위한 네임스페이스

public class SceneMgr1 : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "WALL")
        {
            ChangeScene();
        }
    }

    public void ChangeScene() // 이 함수만 호출하면 씬전환가능
    {
        SceneManager.LoadScene(3);
    }
    /* void Update()
    {
        time = videoClip.length;
        currentTime = video.time;
        if (currentTime >= time)
        {
            ChangeScene();
        }
    } */ // 이건 안됨


}
// cf로 실무에서는 public을 잘 안사용하고, private를(용어가 기억이 안난다.) 써서 [SerializeField]를 써서 사용 이유 직렬화를 하면, private로 해도 public처럼 뜨기 때문
