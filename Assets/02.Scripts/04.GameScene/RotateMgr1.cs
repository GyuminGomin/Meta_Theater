using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMgr1 : MonoBehaviour
{
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = this.gameObject.transform;
        StartCoroutine(tele(15f));
    }

    // Update is called once per frame
    void Update()
    {
        tr.Rotate(1f,1f,1f*Time.deltaTime);
        transform.Translate(Vector3.forward*(-8)*Time.deltaTime, Space.World); // 회전방향과 상관없이 월드좌표계로 이동
    }
    IEnumerator tele(float time)
    {
        yield return new WaitForSeconds(time);
        tr.position = new Vector3(488.218f,1153.386f,20.668f);
        tr.rotation = Quaternion.Euler(90f,0,0);
        this.gameObject.GetComponent<RotateMgr1>().enabled = false;
    }
}
