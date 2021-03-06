using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

public class ControllerManager : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    /* public Image img;
    public TMP_Text posText; */

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
            1. Combine 방식
                PrimaryIndexTrigger - 왼손 트리거
                SecondaryIndexTrigger - 오른손 트리거
            2. Individual 방식
                PrimaryIndexTrigger, LTouch
                PrimaryIndexTrigger, RTouch
        */

        // Combine 방식
        /*   if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) // 인자를 지정안하면 컴바인 형식
          {
              Debug.Log("왼손 트리거 버튼 클릭");
          }

          if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
          {
              Debug.Log("왼손 그립버튼 클릭");
          } */


        // Individual 방식
        // 정전압 방식 터치
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, leftController)) // 인자를 지정안하면 컴바인 형식
        {
            Debug.Log("왼손 트리거 버튼 클릭");
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, leftController))
        {
            Debug.Log("왼손 그립버튼 클릭");
        }
        if (OVRInput.Get(OVRInput.Touch.PrimaryIndexTrigger, rightController))
        {
            Debug.Log("오른손 Index Trigger 터치");
            /* // 버튼을 누르는 감도
            float value = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, rightController);
            img.fillAmount = value; // 0~1까지 값이 반환 */
        }

        // 조이스틱 터치 여부
        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick, rightController))
        {
            Debug.Log("조이스틱 터치");
            /* Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, rightController);
            // print($"pos = ({axis.x}/{axis.y})");
            posText.text = $"pos = ({axis.x:0.00}/{axis.y:0.00})"; // 소수점 2자리 까지 표현하는 C# 포맷팅 방식 */
        }

        // 오른손 그랩 - 진동
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, rightController))
        {
            StartCoroutine(Haptic(0.3f));
        }
    }

    IEnumerator Haptic(float duration)
    {
        OVRInput.SetControllerVibration(0.8f, 0.9f, rightController);
        yield return new WaitForSeconds(duration);
        OVRInput.SetControllerVibration(0, 0, rightController);
    }
}
