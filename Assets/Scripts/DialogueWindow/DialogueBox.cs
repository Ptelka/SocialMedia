using UnityEngine;
using TMPro;

public class DialogueBox : Hoverable2D
{
    private TMP_Text tmp;
    private Vector3 startscale;
    private bool selected = false;

    private void Awake()
    {
        tmp = GetComponentInChildren<TMP_Text>();
        startscale = transform.localScale;
    }

    public void SetText(string text)
    {
        tmp.SetText(text);
    }

    public override void OnHooverIn()
    {
        transform.localScale *= 1.1f;
        selected = true;
    }

    public override void OnHooverOut()
    {
        transform.localScale = startscale;
        selected = false;
    }

    public bool IsSelected()
    {
        return selected;
    }
}
