using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxMessage = 10;

    public  GameObject chatPanel, textObject;

    public InputField ChatBox;

    [SerializeField]
    List<Message> messageList = new List<Message>(); 

    void Start()
    {
        
    }

    
    void Update()
    {
        if(ChatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(ChatBox.text, Message.MessageType.playerMessage);
                ChatBox.text = "";
            }
        }
        else
        {
            if (!ChatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                ChatBox.ActivateInputField();
        }

        if (!ChatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendMessageToChat("You pressed space!", Message.MessageType.info);
                Debug.Log("Space");
            }
        }

        
    }


    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessage)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);

        }

        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);
    }

}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
    public MessageType messageType;

    public enum MessageType
    {
        playerMessage,
        info
    }
}
