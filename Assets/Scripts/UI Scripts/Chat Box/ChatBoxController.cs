using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatBoxController : MonoBehaviour
{
    [SerializeField] GameObject chatPrefab;
    [SerializeField] Scrollbar scrollbar;
    [SerializeField] GameObject chatBox;

    private List<GameObject> chatList = new List<GameObject>();
    [SerializeField] int maxChatCount = 10;
     
    public void AddChat(string playerName, string chatContent)
    {
        GameObject chatObject = Instantiate(chatPrefab);
        chatList.Add(chatObject);
        if(chatList.Count >= maxChatCount)
        {
            Destroy(chatList[0]);
            chatList.RemoveAt(0);
        }
        chatObject.transform.parent = chatBox.transform;

        ChatTextBox chatTextBox = chatObject.GetComponent<ChatTextBox>();
        chatTextBox.SetChatContent(chatContent);
        chatTextBox.SetPlayerName(playerName);
        OnAddedChat();
    }
    public void OnAddedChat()
    {
        scrollbar.value = 1;
    }

    public void GenerateRandomChat()
    {
        List<string> words = new List<string> {
            "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog.",
            "Lorem", "ipsum", "dolor", "sit", "amet,", "consectetur", "adipiscing", "elit.",
            "Sed", "do", "eiusmod", "tempor", "incididunt", "ut", "labore", "et", "dolore", "magna", "aliqua."
        };

        int numSentences = Random.Range(3, 6);
        int minWordsPerSentence = 1;
        int maxWordsPerSentence = 10;

        string paragraph = "";
        for (int i = 0; i < numSentences; i++)
        {
            int numWords = Random.Range(minWordsPerSentence, maxWordsPerSentence + 1);
            List<string> sentenceWords = new List<string>();
            for (int j = 0; j < numWords; j++)
            {
                sentenceWords.Add(words[Random.Range(0, words.Count)]);
            }
            string sentence = string.Join(" ", sentenceWords.ToArray());
            paragraph += char.ToUpper(sentence[0]) + sentence.Substring(1) + ". ";
        }

        AddChat("Player 1", paragraph);
    }
}
