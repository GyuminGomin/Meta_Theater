using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class QuitBut : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,rightController))
        {
            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else  
            Application.Quit();
#endif
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,leftController))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else  
            Application.Quit();
#endif
        }
    }
}
