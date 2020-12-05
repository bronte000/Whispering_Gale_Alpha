using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> speakers;
    public Queue<string> sentences;
    public Queue<Sprite> pictures;
    
    public List<QuestAction> startActions;
    public List<QuestAction> endActions;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image imageBox;
    public GameObject dialogueBox;

    public Animator animator;
    private NextAction nextAction;

    private void DoActions(List<QuestAction> Actions) // acitons that start simultaneously with the quest
    {
        foreach (QuestAction act in Actions)
        {
            act.ExecuteRole();
        }
    }
    
    // Start is called before the first frame update
    void OnEnable()
    {
        speakers = new Queue<string>();
        sentences = new Queue<string>();
        pictures = new Queue<Sprite>();
    }

    public void StartDialogue (Dialogue dialogue, Images images, bool hasImages, NextAction next)
    {
        DoActions(startActions);
        //Debug.Log("Starting conversation with " + dialogue.name); Debug.Log(next.nextSceneName);
        nextAction = next;
        //animator.SetBool("IsOpen", true);
        dialogueBox.SetActive(true);

        //nameText.text = dialogue.name;

        speakers.Clear();
        sentences.Clear();
        pictures.Clear();
        
        foreach (string speaker in dialogue.speakers)
        {
            speakers.Enqueue(speaker);
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

       // Debug.Log("Image");
        if (hasImages)
        {
            foreach (Sprite picture in images.images)
                pictures.Enqueue(picture);
        }

        nameText.text = dialogue.speakers[0];

        if (hasImages)
            DisplayNextImage();

        StartCoroutine(delay(0.65f));
    }

    private IEnumerator delay(float time)
    {
        yield return new WaitForSeconds(time);
        //Debug.Log("delayed");
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if (speakers.Count != 0)
        {
            string speaker = speakers.Dequeue();
            nameText.text = speaker;
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
            yield return new WaitForSeconds(0.01f);
        }
    }

    void EndDialogue()
    {
        //animator.SetBool("IsOpen", false);
        dialogueBox.SetActive(false);
        DoActions(endActions);
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
