using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : Action
{
    [SerializeField] Transform camTransform;
    [SerializeField] float shakeAmount = 0.7f;
    [SerializeField] float shakeDuration = 3f;
    
    float currentShakeDuration = 0.0f;

    Vector3 originalPos;
    
    void Update()
    {
        if (currentShakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
            currentShakeDuration -= Time.deltaTime;
            if (currentShakeDuration < 0)
            {
                currentShakeDuration = 0f;
                camTransform.localPosition = originalPos;
            }
        }
    }

    public override void Execute()
    {
        originalPos = camTransform.localPosition;
        currentShakeDuration = shakeDuration;
        Debug.Log("Shaking camera");
    }
}
