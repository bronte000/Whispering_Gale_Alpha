using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeManager : MonoBehaviour
{
    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialouge (Dialouge dialouge)
    {
        Debug.Log("Starting conversation with " + dialouge.name);

        sentences.Clear();

        foreach(string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialouge();
            return;
        }

        string sentence = sentences.Dequeue();
    }

    void EndDialouge()
    {
        Debug.Log("End of conversation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
