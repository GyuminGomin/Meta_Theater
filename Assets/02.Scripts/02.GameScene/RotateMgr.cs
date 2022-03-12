using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMgr : MonoBehaviour
{
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        tr.Rotate(0,0,10*Time.deltaTime);
    }
}
