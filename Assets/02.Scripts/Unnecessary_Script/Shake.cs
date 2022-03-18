using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float ShakeTime;
    float ShakeIntensity;

    public void OnShakeCamera(float ShakeTime=1f, float ShakeIntensity=0.1f)
    {
        this.ShakeTime = ShakeTime;
        this.ShakeIntensity = ShakeIntensity;
    }
    
    private IEnumerator ShakePosition()
    {
        Vector3 startPosition = transform.position;

        while (ShakeTime > 0.0f )
        {
            transform.position = startPosition + Random.insideUnitSphere * ShakeIntensity;

            ShakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.position = startPosition;
    }
    private IEnumerator ShakeByrotation()
    {
        Vector3 startPosition = transform.eulerAngles;

        float power = 10f;

        while (ShakeTime > 0.0f )
        {   
            float x = 0;
            float y = Random.Range(-1f,1f);
            float z = 0;
            transform.rotation = Quaternion.Euler(startPosition + new Vector3(x, y, z) * ShakeIntensity * power);

            ShakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.rotation = Quaternion.Euler(startPosition);
    }

    void Update()
    {
        
    }
}
