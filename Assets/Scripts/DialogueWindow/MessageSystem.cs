using UnityEngine;
using VIDE_Data;

public class MessageSystem : MonoBehaviour
{
    private MessageBox box;
    private VIDE_Assign dialogue;
    private VD2 vide;
    
    private DialogueSelection selection;
    private MessageScroller scroller;

    private float timer;

    private VD2.NodeData node;

    void Start()
    {
        vide = new VD2();
        selection = GetComponentInChildren<DialogueSelection>();
        scroller = GetComponentInChildren<MessageScroller>();
        
        dialogue = GetComponent<VIDE_Assign>();
        // load?
        NextNode(vide.BeginDialogue(dialogue));
    }

    void NextNode(VD2.NodeData n)
    {
        node = n;
        
        if (node.isEnd)
        {
            Debug.Log("End dialogue: " + vide.assigned.name);
            vide.EndDialogue();
            return;
        }

        if (node.isPlayer)
        {
            selection.SetOptions(node.comments);
        }
        else
        {
            selection.SetOptions(null);
            var time = node.extraData[node.commentIndex];
            if (time != null)
            {
                int x;
                int.TryParse(time, out x);
                timer = x;
            }
        }
    }

    void Update()
    {
        if (!vide.isActive) return;
        
        timer -= Time.deltaTime;

        if (node != null && timer <= 0 && !node.isPlayer)
        {
            scroller.AddNPCMessage(node.comments[node.commentIndex]);
            NextNode(vide.Next());
        }

        if (node.isPlayer)
        {
            var selected = selection.GetSelected();
            if (selected >= 0)
            {
                node.commentIndex = selected;
                selection.ClearSelected();
                scroller.AddPlayerMessage(node.comments[node.commentIndex]);
                NextNode(vide.Next());
            }
        }
    }
}
