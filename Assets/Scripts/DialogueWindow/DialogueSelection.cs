using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSelection : Clickable2D
{
    [SerializeField] private GameObject box;
    [SerializeField] private float radius;
    [SerializeField] private float distance;

    private string[] options = new []{"a", "b", "c"};
    private GameObject[] boxes;
    
    private int selected;

    void Start()
    {
        
    }
    
    public void SetOptions(string[] options)
    {
        this.options = options;
        selected = -1;
    }

    public override void OnStartHold()
    {
        if (options == null)
            return;

        boxes = new GameObject[options.Length];

        for (int i = 0; i < boxes.Length; ++i)
        {
            boxes[i] = Instantiate(box);
            boxes[i].GetComponent<DialogueBox>().SetText(options[i]);
            boxes[i].transform.position = CalculatePosition(boxes.Length, i);
        }
    }

    Vector3 Rotate(Vector3 origin, Vector3 point, float angle)
    {
        Debug.Log("ROtating " + angle);
        angle *= Mathf.Deg2Rad;
        var rotated = new Vector3();
        rotated.x = Mathf.Cos(angle) * (point.x - origin.x) - Mathf.Sin(angle) * (point.y - origin.y) + origin.x;
        rotated.y = Mathf.Sin(angle) * (point.x - origin.x) + Mathf.Cos(angle) * (point.y - origin.y) + origin.y;
        return rotated;
    }
    
    Vector3 CalculatePosition(int count, int i)
    { 
        var position = transform.position;
        position.y += radius;

        var x = i % 2 == 1 ? 1 : -1;
        var y = Mathf.Ceil(i / 2f);
        return Rotate(transform.position, position, 360f - distance * x * y);
    }

    public int GetSelected()
    {
        return selected;
    }

    public void ClearSelected()
    {
        selected = -1;
    }

    public override void OnStopHold()
    {
        if (options == null)
            return;
        
        for (int i = 0; i < boxes.Length; ++i)
        {
            if (boxes[i].GetComponent<DialogueBox>().IsSelected())
            {
                selected = i;
                Debug.Log("Selected dialogue " + selected);
            }
            Destroy(boxes[i]);
        }
    }
}
