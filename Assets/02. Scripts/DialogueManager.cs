using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Queue<Sprite> pictures;

    public Text nameText;
    public Text dialogueText;
    public Image imageBox;

    public Animator animator;
    private NextAction nextAction;

    // Start is called before the first frame update
    void OnEnable()
    {
        sentences = new Queue<string>();
        pictures = new Queue<Sprite>();
    }

    public void StartDialogue (Dialogue dialogue, Images images, bool hasImages, NextAction next)
    {
        //Debug.Log("Starting conversation with " + dialogue.name); Debug.Log(next.nextSceneName);
        nextAction = next;
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();
        pictures.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        if (hasImages)
        {
            foreach (Sprite picture in images.images)
                pictures.Enqueue(picture);
        }

        DisplayNextSentence();
        if (hasImages)
            DisplayNextImage();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        //dialogueText.text = sentence;
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayNextImage()
    {
        if (pictures.Count == 0)
            return;
        Sprite i = pictures.Dequeue();
        imageBox.sprite = i;
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        NextAction(nextAction);
    }

    // what to do at the end of dialogue (NextAction.cs 참고)
    public void NextAction(NextAction next)
    {
        if (next.nextActionCode == 0)
            return;
        else if (next.nextActionCode == 1) //load next scene
            SceneManager.LoadScene(next.nextSceneName);
        else if (next.nextActionCode == 2) //start quest
            next.nextObject.GetComponent<QuestTrigger>().TriggerQuest();
        else if (next.nextActionCode == 3) //start dialogue
            next.nextObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
