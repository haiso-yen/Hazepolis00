using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Message[] messages;
    public Npc[] npcs;

    public void StartDialog()
    {
        FindObjectOfType<DialogManager>().OpenDialog(messages, npcs);
    }
}

[System.Serializable]
public class Message 
{
    public int npcId;
    public string message;
}

[System.Serializable]
public class Npc
{
    public string name;
    public Sprite sprite;
}