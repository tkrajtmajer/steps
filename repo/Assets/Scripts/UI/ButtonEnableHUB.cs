using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnableHUB : MonoBehaviour
{
    public int buttonId;
    GameManager_new gMan;

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        gMan = FindObjectOfType<GameManager_new>();
        CheckEnabled();
    }

    void CheckEnabled()
    {
        if(buttonId != 0 && gMan.levelsCompleted[buttonId-1] == true)
        {
            button.interactable = true;
        }
        else if (buttonId == 0)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }

        
    }

    
}
