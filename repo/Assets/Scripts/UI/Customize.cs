using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Customize : MonoBehaviour
{
    // for now, only menu works, does not affect anything in-game

    public GameObject allPs;
    public GameObject allCs;


    int currentP = 0; // 0-2
    int presentC = 0; // 0-5

    //public Player player;
    GameManager_new gManager;


    void Start()
    {
        gManager = FindObjectOfType<GameManager_new>();

        currentP = gManager.customizedPlayer - 1;
        switch(gManager.customizedColors[0].r)
        {
            case(214 / 255.0f) :
                presentC = 0;
                break;
            case (152 / 255.0f):
                presentC = 1;
                break;
            case (248 / 255.0f):
                presentC = 2;
                break;
            case (42 / 255.0f):
                presentC = 3;
                break;
            case (0 / 255.0f):
                presentC = 4;
                break;
            case (84 / 255.0f):
                presentC = 5;
                break;
        }
        
        allPs.transform.GetChild(currentP).gameObject.SetActive(true);
        allCs.transform.GetChild(presentC).gameObject.SetActive(true);
    }

    // p
    public void RightPressP()
    {
        if(currentP < 2)
        {
            allPs.transform.GetChild(currentP).gameObject.SetActive(false);
            currentP++;
            allPs.transform.GetChild(currentP).gameObject.SetActive(true);
        }
    }
    public void LeftPressP()
    {
        if (currentP > 0)
        {
            allPs.transform.GetChild(currentP).gameObject.SetActive(false);
            currentP--;
            allPs.transform.GetChild(currentP).gameObject.SetActive(true);
        }
    }

    //c
    public void RightPressC()
    {
        if (presentC < 5)
        {
            allCs.transform.GetChild(presentC).gameObject.SetActive(false);
            presentC++;
            allCs.transform.GetChild(presentC).gameObject.SetActive(true);
        }
    }
    public void LeftPressC()
    {
        if (presentC > 0)
        {
            allCs.transform.GetChild(presentC).gameObject.SetActive(false);
            presentC--;
            allCs.transform.GetChild(presentC).gameObject.SetActive(true);
        }
    }


    public void SaveChanges()
    {
        //apply changes (though gManager?)
        // save currentP and presentC /posto su vec saved hm samo pass to gmanager through event
        //instead of affecting player, save to gamemanager, and player loads from gmanager at start


        //p 
        switch (currentP)
        {
            case 0:
                gManager.customizedPlayer = 1;
                break;

            case 1:
                gManager.customizedPlayer = 2;
                break;

            case 2:
                gManager.customizedPlayer = 3;
                break;
        }

        //c
        switch (presentC)
        {
            case 0:
                gManager.customizedColors[0] = new Color(214 / 255.0f, 90 / 255.0f, 78 / 255.0f);
                gManager.customizedColors[1] = new Color(159 / 255.0f, 226 / 255.0f, 136 / 255.0f);
                gManager.customizedColors[2] = new Color(95 / 255.0f, 173 / 255.0f, 217 / 255.0f);
                break;

            case 1:
                gManager.customizedColors[0] = new Color(152 / 255.0f, 243 / 255.0f, 252 / 255.0f);
                gManager.customizedColors[1] = new Color(252 / 255.0f, 151 / 255.0f, 176 / 255.0f);
                gManager.customizedColors[2] = new Color(252 / 255.0f, 193 / 255.0f, 151 / 255.0f);
                break;

            case 2:
                gManager.customizedColors[0] = new Color(248 / 255.0f, 188 / 255.0f, 100 / 255.0f);
                gManager.customizedColors[1] = new Color(252 / 255.0f, 60 / 255.0f, 104 / 255.0f);
                gManager.customizedColors[2] = new Color(186 / 255.0f, 137 / 255.0f, 193 / 255.0f);
                break; 

            case 3:
                gManager.customizedColors[0] = new Color(42 / 255.0f, 157 / 255.0f, 143 / 255.0f);
                gManager.customizedColors[1] = new Color(244 / 255.0f, 162 / 255.0f, 97 / 255.0f);
                gManager.customizedColors[2] = new Color(231 / 255.0f, 111 / 255.0f, 81 / 255.0f);
                break;

            case 4:
                gManager.customizedColors[0] = new Color(0 / 255.0f, 150 / 255.0f, 161 / 255.0f);
                gManager.customizedColors[1] = new Color(255 / 255.0f, 168 / 255.0f, 202 / 255.0f);
                gManager.customizedColors[2] = new Color(51 / 255.0f, 161 / 255.0f, 67 / 255.0f);
                break;

            case 5:
                gManager.customizedColors[0] = new Color(84 / 255.0f, 19 / 255.0f, 136 / 255.0f);
                gManager.customizedColors[1] = new Color(217 / 255.0f, 3 / 255.0f, 104 / 255.0f);
                gManager.customizedColors[2] = new Color(255 / 255.0f, 212 / 255.0f, 0 / 255.0f);
                break;

            default:
                break;
        }

    }

}
