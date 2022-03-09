using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VolumeBut : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    public Sprite on_image;
    public Sprite off_image;
    public VideoPlayer my_video;
    private SpriteRenderer my_renderer;
    private bool isMuted = false;

    void Start()
    {
        my_renderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void IndexTriggerButClick_R()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,rightController))
        {
            if (isMuted == true)
            {
            // 음소거가 참이라면 = 음소거 상태라면
            my_renderer.sprite = on_image;
            my_video.SetDirectAudioMute(0, false); // 트랙번호, 뮤트를 할거나 말거냐
            isMuted = false;
            }
            else
            {
            // 음소거가 거짓이라면 = 소리가 나오고 있다면
            my_renderer.sprite = off_image;
            my_video.SetDirectAudioMute(0, true); // 트랙번호, 뮤트를 할거나 말거냐
            isMuted = true;
            }
        }
    }
    void IndexTriggerButClick_L()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,leftController))
        {
            if (isMuted == true)
            {
            // 음소거가 참이라면 = 음소거 상태라면
            my_renderer.sprite = on_image;
            my_video.SetDirectAudioMute(0, false); // 트랙번호, 뮤트를 할거나 말거냐
            isMuted = false;
            }
            else
            {
            // 음소거가 거짓이라면 = 소리가 나오고 있다면
            my_renderer.sprite = off_image;
            my_video.SetDirectAudioMute(0, true); // 트랙번호, 뮤트를 할거나 말거냐
            isMuted = true;
            }
        }
    }

    void Update()
    {
        /* IndexTriggerButClick_R();
        IndexTriggerButClick_L(); */
    }

    void OnColliderStay(Collider col)
    {
        if (col.gameObject.name == "OVRControllerPrefab")
        {
            IndexTriggerButClick_R();
        }
    }
    /* private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "OVRControllerPrefab")
        {
            
        }
    } */
}
