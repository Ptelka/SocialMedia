using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButton : Clickable2D
{
    [SerializeField] private GameObject go;

    public override void OnStopHold()
    {
        go.SetActive(false);
    }
}
