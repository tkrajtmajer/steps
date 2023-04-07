using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPC : MonoBehaviour
{
    //public bool canTalk; 
	public Dialogue dialogue;
    public event Action DialogueOn;
    public event Action DialogueOff;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            DialogueOn?.Invoke();
            //canTalk = true;
            TriggerDialogue();
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DialogueOff?.Invoke();
            //canTalk = false;
            
        }
    }
}