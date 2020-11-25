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

    public bool changeSceneWhenFinished;
    public string nextSceneName;

    // Start is called before the first frame update
    void OnEnable()
    {
        sentences = new Queue<string>();
        pictures = new Queue<Sprite>();
    }

    public void StartDialogue (Dialogue dialogue, Images images, bool hasImages)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);
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
        if (changeSceneWhenFinished)
            SceneManager.LoadScene(nextSceneName);
    }
}
