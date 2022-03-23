using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetVisible : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    private Rigidbody rigid;
    [SerializeField]
    GameObject startView;
    [SerializeField]
    GameObject notice_canvas;
    bool isStart = true;
    int data = 0; // 이전으로 되돌아 가기 위한 변수
    private GameObject SoundObject;
    public string effSoundName = "Jump";
    public string effSoundName1 = "Run";

    // Start is called before the first frame update
    void Start()
    {
        notice_canvas.SetActive(false);
        rigid = this.gameObject.transform.root.GetComponent<Rigidbody>();
        SoundObject = GameObject.Find("JumpSound");
    }

    // Update is called once per frame
    void Update()
    {   
        if (isStart)
        {
            if (OVRInput.GetDown(OVRInput.Button.One,rightController))
            {
                rigid.AddForce(Vector3.up*5,ForceMode.Impulse);
                SoundObject.GetComponent<PlayerCtrlSound>().PlaySound(effSoundName);
            }
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickUp,leftController))
        {
            SoundObject.GetComponent<PlayerCtrlSound>().PlaySound(effSoundName1);
            SoundObject.GetComponent<PlayerCtrlSound>().GetComponent<AudioSource>().loop = true;
        } 
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickUp,leftController))
        {
            SoundObject.GetComponent<PlayerCtrlSound>().GetComponent<AudioSource>().loop = false;
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown,leftController))
        {
            SoundObject.GetComponent<PlayerCtrlSound>().PlaySound(effSoundName1);
            SoundObject.GetComponent<PlayerCtrlSound>().GetComponent<AudioSource>().loop = true;
        } 
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickDown,leftController))
        {
            SoundObject.GetComponent<PlayerCtrlSound>().GetComponent<AudioSource>().loop = false;
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight,leftController))
        {
            SoundObject.GetComponent<PlayerCtrlSound>().PlaySound(effSoundName1);
            SoundObject.GetComponent<PlayerCtrlSound>().GetComponent<AudioSource>().loop = true;
        } 
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickRight,leftController))
        {
            SoundObject.GetComponent<PlayerCtrlSound>().GetComponent<AudioSource>().loop = false;
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft,leftController))
        {
            SoundObject.GetComponent<PlayerCtrlSound>().PlaySound(effSoundName1);
            SoundObject.GetComponent<PlayerCtrlSound>().GetComponent<AudioSource>().loop = true;
        } 
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickLeft,leftController))
        {
            SoundObject.GetComponent<PlayerCtrlSound>().GetComponent<AudioSource>().loop = false;
        }
        StartCoroutine(OneBtn());
    }

    IEnumerator OneBtn()
    {
        if (isStart && data==0)
        {
            if (OVRInput.GetDown(OVRInput.Button.One,leftController))
            {
                startView.SetActive(false);
                notice_canvas.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                isStart = false;
                data += 1; // data = 1
            }
        }
        if  (data==1)
        {
            if (OVRInput.GetDown(OVRInput.Button.One,leftController))
            {
                data -= 1;
                isStart = true;
                SceneManager.LoadScene(2);
            }
            if (OVRInput.GetDown(OVRInput.Button.One,rightController))
            {
                notice_canvas.SetActive(false);
                data -= 1; // data = 0
                isStart = true;
            }
        }
    }
}
