using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChSc4_video : MonoBehaviour
{
    private Transform tr;
    
    void Start()
    {
        tr = this.gameObject.transform;
        StartCoroutine(change());
    }

    // Update is called once per frame
    void Update()
    {
        tr.transform.position += new Vector3(1*Time.deltaTime,0,0);
    }
    public void ChangeScene() // 이 함수만 호출하면 씬전환가능
    {
        SceneManager.LoadScene(8); // 02.GameScene으로 전환
    }
    IEnumerator change()
    {
        yield return new WaitForSeconds(5.0f);
        ChangeScene();
    }
}
