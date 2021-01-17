using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Browser : MonoBehaviour
{
    //[SerializeField] private GameObject[] conversations;
    [SerializeField] private GameObject currentConversation;
    [SerializeField] private GameObject friendsContent;
    [SerializeField] private GameObject friendLabel;

    private void Start()
    {
        var conversations = transform.Find("Conversations");
        var content = friendsContent.transform;

        for (int i = 0; i < conversations.childCount; ++i)
        {
            var conversation = conversations.GetChild(i).gameObject;
            var label = Instantiate(friendLabel, content, true);
            var button = label.GetComponent<Button>();
            var tmp = button.GetComponentInChildren<TMP_Text>();
            
            tmp.SetText(conversation.GetComponent<VIDE_Assign>().name);
            button.onClick.AddListener(() => UpdateConversation(conversation));
        }
    }

    void UpdateConversation(GameObject conversation)
    {
        var old = conversation.transform.position;
        conversation.transform.position = currentConversation.transform.position;
        currentConversation.transform.position = old;
        currentConversation = conversation;
    }
}
