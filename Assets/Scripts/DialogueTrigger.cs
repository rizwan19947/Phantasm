using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    [SerializeField] Dialogue dialogue;
    [SerializeField] GameObject dialogueTrigger;
    Player refPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Player")
        {
            TriggerDialogue();
            dialogueTrigger.SetActive(false);
            refPlayer = collision.GetComponent<Player>();
            refPlayer.ToggleCanControl(false);
        }
    }




    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }

    public void DialogueEnded()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        playerObj.GetComponent<Player>().ToggleCanControl(true);

    }



}
