using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class QuitBut3 : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    private bool isQuit = false;
    public TMP_Text notice;
    [SerializeField]
    private GameObject canvas;
    private Rigidbody rigid;

    void Start()
    {
        canvas.SetActive(false);
        rigid = this.gameObject.transform.root.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One,rightController))
        {
            rigid.AddForce(Vector3.up*0.5f,ForceMode.Impulse);
            OVRInput.SetControllerVibration(0.8f, 0.9f, rightController);
            OVRInput.SetControllerVibration(0.8f, 0.9f, leftController);
        }
        StartCoroutine(Quit());  
    }
    IEnumerator Quit()
    {
        if(!isQuit)
        {
            if (OVRInput.GetDown(OVRInput.Button.Two,leftController))
            {
                canvas.SetActive(true);
                notice.text = "Do you want to Quit? \n y : Left click again \n n : Right click again";
                yield return new WaitForSeconds(0.5f);
                isQuit = true;
            }
        }
        if(isQuit)
        {
            if (OVRInput.GetDown(OVRInput.Button.Two,leftController))
            {
                canvas.SetActive(false);
                Application.Quit();
            }
            if (OVRInput.GetDown(OVRInput.Button.Two,rightController)) // 나가기 취소
            {
                isQuit = false;
                canvas.SetActive(false);
            }
        }
    }
}
