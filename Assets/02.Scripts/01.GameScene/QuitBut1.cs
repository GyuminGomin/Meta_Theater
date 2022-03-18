using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class QuitBut1 : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    private bool isQuit = false;
    public TMP_Text notice;
    [SerializeField]
    private GameObject canvas;

    void Start()
    {
        canvas.SetActive(false);
    }
    void Update()
    {
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
                yield return new WaitForSeconds(2f);
                isQuit = true;
            }
        }
        if(isQuit)
        {
            if (OVRInput.GetDown(OVRInput.Button.Two,leftController))
            {
                canvas.SetActive(false);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else  
            Application.Quit();
#endif
            }
            if (OVRInput.GetDown(OVRInput.Button.Two,rightController)) // 나가기 취소
            {
                isQuit = false;
                canvas.SetActive(false);
            }
        }
    }
}
