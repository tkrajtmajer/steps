using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public Text dialogueText;


	private Queue<string> sentences;

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();
	}

    void Update()
    {
        if(Input.anyKeyDown)
        {
			DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
	{


		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		
		DisplayNextSentence();
		
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		/*
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));*/

		string sentence = sentences.Dequeue();
		dialogueText.text = sentence;
	}

	/*
	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}*/

	void EndDialogue()
	{
		//etwass
		dialogueText.enabled = false;
	}

}