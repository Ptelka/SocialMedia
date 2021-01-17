
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    private TMP_Text tmp;

    private void Awake()
    {
        tmp = GetComponentInChildren<TMP_Text>();
    }

    public void SetText(string text)
    {
        tmp.SetText(text);
    }
}
