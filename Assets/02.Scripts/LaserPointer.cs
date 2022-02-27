using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    private RaycastHit hit;
    // 라인 랜더러 만들 것
    private LineRenderer line;
    public Color color = Color.blue;
    public float maxDistance = 50.0f;
    public Transform laserMaker;

    // Start is called before the first frame update
    void Start()
    {
        CreateLineRenderer();
    }

    void CreateLineRenderer()
    {
        // LineRenderer 추가
        line = this.gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.receiveShadows = false;

        // 시작, 끝 지점 설정
        line.positionCount = 2;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, Vector3.forward * maxDistance);

        // 라인의 폭 설정
        line.startWidth = 0.03f; // 시작점의 폭
        line.endWidth = 0.005f; // 끝지점의 폭
        line.numCapVertices = 10; // 끝지점의 vertax를 둥글게

        // 라인의 머티리얼 지정하고 색상을 설정
        line.material = new Material(Shader.Find("Unlit/Color")); // unlit은 unlight의 약자
        line.material.color = this.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            line.SetPosition(1, Vector3.forward * hit.distance);
            laserMaker.position = hit.point + laserMaker.forward * 0.001f;
            // 각도를 법선벡터 방향으로 회전
            laserMaker.rotation = Quaternion.LookRotation(hit.normal);
            laserMaker.GetComponent<SpriteRenderer>().color = Color.yellow;

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                StartCoroutine(Teleport(hit.point));
            }
            /* #if UNITY_EDITOR
                        if (Input.GetMouseButtonDown(0))
                        {
                            StartCoroutine(Teleport(hit.point));
                        }
            #endif */
        }
        else
        {
            line.SetPosition(1, Vector3.forward * maxDistance);
            laserMaker.position = transform.position + (transform.forward * maxDistance);
            laserMaker.rotation = Quaternion.LookRotation(transform.forward);
            laserMaker.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    IEnumerator Teleport(Vector3 pos)
    {
        OVRScreenFade.instance.fadeTime = 0.0f;
        OVRScreenFade.instance.FadeOut(); // 여기까지가 화면을 블랙으로

        transform.root.position = pos + (Vector3.up * 1.8f);

        yield return new WaitForSeconds(0.1f);

        OVRScreenFade.instance.fadeTime = 0.2f;
        OVRScreenFade.instance.FadeIn();
    }
}

/*
    ADB가 반드시 설치되어 있어야 함

    명령 프롬프트
    Gitbash shell에서 이 명령어를 반드시 써야함


    // 근접센서 비활성화 ( 배터리는 빨리 닳음 )  --- oculus 커맨드 맵 이라는 것을 검색하면 더 유용한걸 찾을 수 있다.
    > adb shell am broadcast -a com.oculus.vrpowermanager.automation_disable
    // 근접센서 활성화
    $ adb shell am broadcast -a com.oculus.vrpowermanager.prox_close
*/
