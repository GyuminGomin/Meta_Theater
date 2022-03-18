using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reGen : MonoBehaviour
{
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (tr.position.y > 40)
        {
            tr.position = new Vector3(0,0,0);
        }
    }
}
