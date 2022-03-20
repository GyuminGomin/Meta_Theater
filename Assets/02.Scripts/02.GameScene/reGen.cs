using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reGen : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    Transform tr;
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        tr = this.gameObject.transform;
        rigid = this.gameObject.transform.root.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tr.position.y > 40)
        {
            tr.position = new Vector3(0,0,0);
        }

        if (OVRInput.Get(OVRInput.Button.One,rightController))
        {
            rigid.AddForce(Vector3.up*0.5f,ForceMode.Impulse);
            OVRInput.SetControllerVibration(0.8f, 0.9f, rightController);
            OVRInput.SetControllerVibration(0.8f, 0.9f, leftController);
        }
    }
}
