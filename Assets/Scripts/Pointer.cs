using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private Camera cam;

    class Data
    {
        public Data(Clickable2D clickable)
        {
            this.clickable = clickable;
        }
        
        public Data(Hoverable2D hoverable)
        {
            this.hoverable = hoverable;
        }
        
        public Clickable2D clickable;
        public Hoverable2D hoverable;
    }
    
    private Clickable2D holding = null;
    private Hoverable2D hovering = null;

    void Start()
    {
        cam = FindObjectOfType<ComputerController>().GetComputerCamera();
    }

    Vector2 UpdatePosition()
    {
        var pos = transform.position;
        var newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        pos.x = newPos.x;
        pos.y = newPos.y;

        transform.position = pos;
        return pos;
    }

    void OnClick(Clickable2D clickable)
    {
        Debug.Log("OnClick: " + clickable.gameObject.name);
        clickable.OnClick();
    }


    void OnStartHolding(Clickable2D clickable)
    {
        Debug.Log("OnStartHolding: " + clickable.gameObject.name);
        holding = clickable;
        holding.OnStartHold();
    }

    void OnStopHolding()
    {
        Debug.Log("OnStopHolding: " + holding.gameObject.name);
        holding.OnStopHold();
        holding = null;
    }
    
    void OnStopHovering()
    {
        Debug.Log("OnStopHoovering: " + hovering.gameObject.name);
        hovering.OnHooverOut();
        hovering = null;
    }

    
    void OnStartHovering(Hoverable2D hoverable)
    {
        hovering = hoverable;
        Debug.Log("OnStartHoovering: " + hovering.gameObject.name);
        hovering.OnHooverIn();
    }


    void Update()
    {
        var pos = UpdatePosition();
        CheckInput(pos);
    }

    void CheckInput(Vector2 pos)
    {
        var data = GetData(pos);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (data != null && data.clickable) {
                OnClick(data.clickable);
                OnStartHolding(data.clickable);
            }
        }
        
        if (Input.GetMouseButtonUp(0) && holding)
        {
            OnStopHolding();
        }

        if (data != null && data.hoverable && !hovering)
        {
            OnStartHovering(data.hoverable);
        }

        if (hovering && (data == null || data.hoverable != hovering))
        {
            OnStopHovering();
            if (data != null && data.hoverable)
                OnStartHovering(data.hoverable);
        }
    }
    
    Data GetData(Vector2 pos)
    {
        var hit = Physics2D.Raycast(pos, Vector2.zero);

        if (!hit.collider) return null;

        if (hit.collider.CompareTag("clickable"))
        {
            return new Data(hit.collider.GetComponent(typeof(Clickable2D)) as Clickable2D);
        }

        if (hit.collider.CompareTag("hoverable"))
        {
            return new Data(hit.collider.GetComponent(typeof(Hoverable2D)) as Hoverable2D);
        }

        return null;
    }

}
