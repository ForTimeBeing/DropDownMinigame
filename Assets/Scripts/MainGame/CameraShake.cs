using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    float shakeAmount = 0;

    public static bool shakeScreen = false;

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

        if (CameraShake.shakeScreen == true)
        {
            Shake(.4f, .3f);
            StartCoroutine(stoptheshake());
        }
    }
    void StopShake()
    {
        CancelInvoke("BeginShake");
        gameObject.transform.localPosition = Vector3.zero;
    }
    IEnumerator stoptheshake()
    {
        yield return new WaitForSeconds(.3f);
        CameraShake.shakeScreen = false;
    }
}
