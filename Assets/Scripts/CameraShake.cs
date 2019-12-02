using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    float shakeAmount = 0;

    public void Shake(float amt, float length)
    {
        shakeAmount = amt;
        InvokeRepeating("BeginShake", 0, 1f);
        Invoke("StopShake", length);

    }
    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = gameObject.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;

            gameObject.transform.position = camPos;
        }
    }
    void Update()
    {
        //Shake(0.3f,.3f);
    }
    void StopShake()
    {
        CancelInvoke("BeginShake");
        gameObject.transform.localPosition = Vector3.zero;
    }
}
