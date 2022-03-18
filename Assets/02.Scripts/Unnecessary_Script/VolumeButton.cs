using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VolumeButton : MonoBehaviour
{
    public Sprite on_image;
    public Sprite off_image;
    public VideoPlayer my_video;
    private SpriteRenderer my_renderer;
    private bool isMuted = false;
    void OnMouseDown()
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
    // Start is called before the first frame update
    void Start()
    {
        my_renderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
