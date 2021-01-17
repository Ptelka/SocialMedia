using System.Collections.Generic;
using UnityEngine;

public class MessageScroller : MonoBehaviour
{
    [SerializeField] private GameObject npcMessage;
    [SerializeField] private GameObject playerMessage;
    
    public void AddPlayerMessage(string text)
    {
        var message = Instantiate(playerMessage, transform);
        message.GetComponent<MessageBox>().SetText(text);
    } 
    
    public void AddNPCMessage(string text)
    {
        var message = Instantiate(npcMessage, transform);
        message.GetComponent<MessageBox>().SetText(text);
    } 
    
    public void AddObject(GameObject obj)
    {
        var message = Instantiate(obj, transform);
    } 
}
