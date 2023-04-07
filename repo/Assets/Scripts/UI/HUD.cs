using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    
    public GameObject dialogueUI;
    NPC[] npcList;


    // Start is called before the first frame update
    void Start()
    {

        npcList = FindObjectsOfType<NPC>();

        foreach (NPC npc in npcList)
        {
            npc.DialogueOn += ShowDialogue;
            npc.DialogueOff += HideDialogue;
        }

        dialogueUI.SetActive(false);
    }

    

    public void ShowDialogue()
    {
        dialogueUI.SetActive(true);
    }

    public void HideDialogue()
    {
        dialogueUI.SetActive(false);
    }

   

}
