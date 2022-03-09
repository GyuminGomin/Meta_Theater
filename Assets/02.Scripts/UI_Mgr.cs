using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class UI_Mgr : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,rightController))
        {
            Debug.Log("오른쪽 버튼 눌림");
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,leftController))
        {
            Debug.Log("왼쪽 버튼 눌림");
        }
    }
}
