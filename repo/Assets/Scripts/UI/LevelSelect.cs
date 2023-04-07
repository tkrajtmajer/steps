using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    //use these when going to levels from HUB

    public Animator transition;

    public float transTime = 1;

    GameManager_new gMan;
    bool[] whichLevelsAreDone = new bool[10];

    void Start()
    {
        //triggered by event, when player chooses next level 
        //do I even need this script th0?

        //aj za sad cu samo copy brackeys pa change l8r
        gMan = FindObjectOfType<GameManager_new>();
        for(int i = 0; i<10; i++)
        {
            whichLevelsAreDone[i] = gMan.levelsCompleted[i];
        }
    }


    public void Zero_LoadLevel()
    {
        StartCoroutine(LoadLevel(2));

    }
    public void One_LoadLevel()
    {
        if (whichLevelsAreDone[0] == true)
        {
            StartCoroutine(LoadLevel(3));
        }
    }
    public void Two_LoadLevel()
    {
        if (whichLevelsAreDone[1] == true)
        {
            StartCoroutine(LoadLevel(4));
        }
    }
    public void Three_LoadLevel()
    {
        if (whichLevelsAreDone[2] == true)
        {
            StartCoroutine(LoadLevel(5));
        }
    }
    public void Four_LoadLevel()
    {
        if (whichLevelsAreDone[3] == true)
        {
            StartCoroutine(LoadLevel(6));
        }
    }
    public void Five_LoadLevel()
    {
        if (whichLevelsAreDone[4] == true)
        {
            StartCoroutine(LoadLevel(7));
        }
    }
    public void Six_LoadLevel()
    {
        if (whichLevelsAreDone[5] == true)
        {
            StartCoroutine(LoadLevel(8));
        }
    }
    public void Seven_LoadLevel()
    {
        if (whichLevelsAreDone[6] == true)
        {
            StartCoroutine(LoadLevel(9));
        }
    }
    public void Eight_LoadLevel()
    {
        if (whichLevelsAreDone[7] == true)
        {
            StartCoroutine(LoadLevel(10));
        }
    }
    public void Nine_LoadLevel()
    {
        if (whichLevelsAreDone[8] == true)
        {
            StartCoroutine(LoadLevel(11));
        }
    }

    IEnumerator LoadLevel(int lvlIndex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(lvlIndex);
    }
}
