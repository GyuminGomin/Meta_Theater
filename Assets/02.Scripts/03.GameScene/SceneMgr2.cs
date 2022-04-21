using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Scene전환하기 위한 네임스페이스
using TMPro;

public class SceneMgr2 : MonoBehaviour
{
    public TMP_Text notice;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject canvas_Translate;

    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "WALL")
        {
            StartCoroutine(delayT());
        }
    }

    IEnumerator delayT()
    {
        canvas.SetActive(true);
        canvas_Translate.SetActive(false);

        notice.text = "3";
        yield return new WaitForSeconds(1f);
        notice.text = "2";
        yield return new WaitForSeconds(1f);
        notice.text = "1";
        yield return new WaitForSeconds(1f);
        ChangeScene();
    }

    public void ChangeScene() // 이 함수만 호출하면 씬전환가능
    {
        SceneManager.LoadScene(5);
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
