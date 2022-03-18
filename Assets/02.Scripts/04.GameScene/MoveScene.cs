using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    private Transform tr;
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    // Start is called before the first frame update
    void Start()
    {
        tr = this.gameObject.transform;
        StartCoroutine(Haptic(0.5f,1f));
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
        SceneManager.LoadScene(5);
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
}
