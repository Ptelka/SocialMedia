using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : Clickable2D
{
    private bool isDragged = false;
    private ComputerController controller;
    private Vector3 mouseDelta = Vector3.zero;

    void Awake()
    {
        controller = FindObjectOfType<ComputerController>();
    }
    
    void Update()
    {
        if (isDragged)
        {
            transform.position = controller.GetComputerCamera().ScreenToWorldPoint(Input.mousePosition) - mouseDelta;
        }
    }
    
    public override void OnStartHold()
    {
        isDragged = true;
        var mousePos =  controller.GetComputerCamera().ScreenToWorldPoint(Input.mousePosition);
        mouseDelta = mousePos - transform.position;
    }

    public override void OnStopHold()
    {
        isDragged = false;
    }
}
