using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PauseButton : MonoBehaviour
{
    public VideoPlayer my_video;
    void OnMouseDown()
    {
        my_video.Pause();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}