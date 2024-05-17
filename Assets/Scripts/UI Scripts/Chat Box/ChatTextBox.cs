using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatTextBox : MonoBehaviour
{
    [SerializeField] Text chatContent;
    [SerializeField] Text playerName;

    public void SetPlayerName(string playerName)
    {
        this.playerName.text = playerName + " :";
    }

    public void SetChatContent(string chatContent)
    {
        this.chatContent.text = chatContent;
    }
}
