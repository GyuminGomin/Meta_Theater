using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MoveScene : MonoBehaviour
{
    private Transform tr;
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    public TMP_Text notice;
    [SerializeField]
    private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        tr = this.gameObject.transform;
        StartCoroutine(Haptic(0.5f,1f));
        StartCoroutine(Notice());
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(moveScene(15f, 15f));
    }

    IEnumerator moveScene(float time, float time2)
    {
        yield return new WaitForSeconds(time);
        transform.Translate(Vector3.up*(-41)*Time.deltaTime, Space.World);
        yield return new WaitForSeconds(time2);
        SceneManager.LoadScene(7);
    }
    IEnumerator Haptic(float time, float time1)
    {
        for (int i =0; i<20; i++)
        {
            yield return new WaitForSeconds(time); // 0.5
            OVRInput.SetControllerVibration(0.8f, 0.9f, rightController);
            OVRInput.SetControllerVibration(0.8f, 0.9f, leftController);
            yield return new WaitForSeconds(time1); // 1
            OVRInput.SetControllerVibration(0f, 0f, rightController);
            OVRInput.SetControllerVibration(0f, 0f, leftController);
        }
    }
    IEnumerator Notice()
    {
        yield return new WaitForSeconds(27f);
        canvas.SetActive(true);
        notice.text = "3";
        yield return new WaitForSeconds(1f);
        notice.text = "2";
        yield return new WaitForSeconds(1f);
        notice.text = "1";
        yield return new WaitForSeconds(1f);
    }
}
