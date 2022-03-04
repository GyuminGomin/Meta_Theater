using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Scene전환하기 위한 네임스페이스

public class SceneMgr : MonoBehaviour
{/* 
    public GameObject changeScene;
    // public int target_scene = 0; // 씬 전환 방법은 여러가지가 있음 까먹지 않도록 필요없지만 넣어놨음
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayTime(2));
    }

    IEnumerator DelayTime(float time) // 내 프로젝트는 무조건 Scene전환을 해야하지만, 참고로 SetActive함수쓰는 법
    {
        yield return new WaitForSeconds(time);

        changeScene.SetActive(false);
    } */

    public void ChangeScene() // 이 함수만 호출하면 씬전환가능
    {
        SceneManager.LoadScene(1); // 참고로 VR은 쪼금 연구하고 넣어야 겠다.ㅋ
    }
}
// cf로 실무에서는 public을 잘 안사용하고, private를(용어가 기억이 안난다.) 써서 [SerializeField]를 써서 사용 이유 직렬화를 하면, private로 해도 public처럼 뜨기 때문
