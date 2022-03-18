using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer_02 : MonoBehaviour
{
    private RaycastHit hit;
    // 라인 랜더러 만들 것
    private LineRenderer line; // 라인랜더러를 추가해주기 위한 선언
    public Color color = Color.blue; // 라인 색깔
    public float maxDistance = 50.0f; // 광선의 도달 범위
    public Transform laserMaker; // 레이저마커 연결하기 위해 선언
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    private Rigidbody rigid;
    private Vector2 axis;
    [SerializeField]
    private float speed = 5;
    private bool isRaser = false;
    // public GameObject came;


    // Start is called before the first frame update
    void Start()
    {
        CreateLineRenderer();
        rigid = this.gameObject.transform.root.GetComponent<Rigidbody>();
    }

    void CreateLineRenderer()
    {
        // LineRenderer 추가
        line = this.gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false; // 월드스페이스 제거
        line.receiveShadows = false; // 그림자 제거

        // 시작, 끝 지점 설정
        line.positionCount = 2;
        line.SetPosition(0, Vector3.zero); // 라인의 초기 위치
        line.SetPosition(1, Vector3.forward * maxDistance); // 라인의 끝점 위치

        // 라인의 폭 설정
        line.startWidth = 0.03f; // 시작점의 폭
        line.endWidth = 0.005f; // 끝지점의 폭
        line.numCapVertices = 10; // 끝지점의 vertax를 둥글게 0~10까지

        // 라인의 머티리얼 지정하고 색상을 설정 (소스코드로 material생성)
        line.material = new Material(Shader.Find("Unlit/Color")); // unlit은 unlight의 약자 라이트가 없어도 색깔이 보이게 설정해주는 것 (참고로 unlit은 투명상태 지정 불가능)
        line.material.color = this.color;
    }


    // Update is called once per frame
    void Update()
    {
        move();
        if (OVRInput.Get(OVRInput.Button.One,rightController))
        {
            rigid.AddForce(Vector3.up*0.5f,ForceMode.Impulse);
            OVRInput.SetControllerVibration(0.8f, 0.9f, rightController);
            OVRInput.SetControllerVibration(0.8f, 0.9f, leftController);
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight,rightController))
        {
            transform.root.Rotate(Vector3.up *22.5f);
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft,rightController))
        {
            transform.root.Rotate(Vector3.up *-22.5f);
        }
        raserCtr();
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            // 무언가 맞게 되면 맞은 지점까지의 설정
            line.SetPosition(1, Vector3.forward * hit.distance); // 라인이 부딪힌거리까지가 hit.distance
            laserMaker.position = hit.point + laserMaker.forward * 0.001f; // 실행시켜 레이저가 바라보는 방향을 보고 +를 해줘야함
            // 각도를 법선벡터 방향으로 회전
            laserMaker.rotation = Quaternion.LookRotation(hit.normal); // 맞은지점에서 수직을 이루는 (법선벡터)
            laserMaker.GetComponent<SpriteRenderer>().color = Color.yellow;
            /* #if UNITY_EDITOR // 전처리기 이것은 유니티 에디터에서만 실행된다는 의미의 전처리기
                        if (Input.GetMouseButtonDown(0))
                        {
                            StartCoroutine(Teleport(hit.point));
                        }
            #endif */
        }
        else
        {
            line.SetPosition(1, Vector3.forward * maxDistance); //안 부딪히면 맥스로
            laserMaker.position = transform.position + (transform.forward * maxDistance); // 컨트롤러 피벗좌표로부터 레이저 끝점 위치로
            laserMaker.rotation = Quaternion.LookRotation(transform.forward); // 방향을 레이저 끝점을 바라보도록
            laserMaker.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void move()
    {
        //Vector3 cam_pos=new Vector3(came.transform.position.x,0,came.transform.position.z); // 이렇게 쓰는 순간 값이 급격하게 상승하더라.. EyeAnchor에 출력되는 값과 다르게 최대의 값이 나오네..ㄷㄷ
        axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, leftController);
        float fixedY = transform.root.position.y;
        transform.root.position += (transform.right * axis.x + transform.forward * axis.y) * Time.deltaTime * speed /*+ (cam_pos) */;
        transform.root.position = new Vector3(transform.root.position.x, fixedY, transform.root.position.z);
    }

    void raserCtr()
    {
        if (isRaser)
        {
            if (OVRInput.GetDown(OVRInput.Button.Two,rightController))
            {
                line.enabled = false;
                laserMaker.gameObject.SetActive(false);
                isRaser = false;
            }
        }
        else
        {
            if (OVRInput.GetDown(OVRInput.Button.Two,rightController))
            {
                line.enabled = true;
                laserMaker.gameObject.SetActive(true);
                isRaser = true;
            }
        }
    }
}