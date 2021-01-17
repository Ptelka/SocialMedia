using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : Dragable
{
    private float lastClickTime;
    [SerializeField] GameObject obj;

    void Start()
    {
        lastClickTime = Time.time;
    }
    
    public override void OnStopHold()
    {
        base.OnStopHold();
        if (Time.time - lastClickTime <= 0.4)
        {
            obj.SetActive(true);
        }

        lastClickTime = Time.time;
    }
}
