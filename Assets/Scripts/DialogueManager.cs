using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{

    [SerializeField] Text dialogueText;
    [SerializeField] Animator animator;
    [SerializeField] Player refPlayer;
    DialogueTrigger dialogueTriggerRef = new DialogueTrigger();
    private bool dialogueManagerActive = false;
    private Queue<string> sentences; 

    void Start()
    {

        sentences = new Queue<string>();
            
    }

    private void Update()
    {
        if((dialogueManagerActive==true) && Input.GetKeyDown(KeyCode.Space)==true)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueManagerActive = true;

        Debug.Log("Starting Conversation");

        animator.SetBool("IsOpen", true);


        sentences.Clear();


        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();


    }



    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }
    
    private void EndDialogue()
    {
        dialogueManagerActive = false;
        animator.SetBool("IsOpen", false);
        Debug.Log("Conversation End");

        dialogueTriggerRef.DialogueEnded();

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }


}
