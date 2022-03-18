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
}
