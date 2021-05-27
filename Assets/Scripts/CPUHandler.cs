using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CPUHandler : MonoBehaviour
{
    public Button send;
    //public InputField input;
    public TMP_Text answer;
    public AudioSource voice1;
    public AudioSource voice2;
    public AudioSource voice3;
    public AudioSource voice4;
    public AudioSource voice5;
    private List<AudioSource> convo;
    private List<string> chat;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        answer.text = "";
        send.onClick.AddListener(TaskOnClick);
        convo = new List<AudioSource>{voice1, voice2, voice3, voice4, voice5};
        chat = new List<string> { "Greetings! My name is Query-Chan, nice to meet you.", "Yes, yes!", "Today is a sunny day in Tokyo", "Grab some ramen down the street!", "See you!" };

    }

    void TaskOnClick()
    {
        convo[i].gameObject.SetActive(true);
        answer.text = chat[i];
        
        if(i < convo.Count - 1)
        {
            i++;
        }
        else
        {
            send.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
