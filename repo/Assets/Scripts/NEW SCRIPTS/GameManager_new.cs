using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_new : MonoBehaviour
{
    public int customizedPlayer;
    public Color[] customizedColors = new Color[3];

    //level-handling  (bazicno)
    public bool[] levelsCompleted = new bool[10];

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        //set default player
        customizedPlayer = 1;

        //set default colors
        customizedColors[0] = new Color(214 / 255.0f, 90 / 255.0f, 78 / 255.0f, 255f);
        customizedColors[1] = new Color(159 / 255.0f, 226 / 255.0f, 136 / 255.0f, 255f);
        customizedColors[2] = new Color(95 / 255.0f, 173 / 255.0f, 217 / 255.0f, 255f);

        PlayerData data = SaveSystem.Load();
        if (data != null)
        {
            Load();
        }
              
    }

    //handle save data
    public void Save()
    {
        SaveSystem.Save(this);
    }

    public void Load()
    {
        PlayerData data = SaveSystem.Load();

        for(int i = 0; i < 10; i++)
        {
            levelsCompleted[i] = data.levelsFinished[i];
        }

        customizedPlayer = data.customizedPlayerSaveData;

        for(int i = 0; i < 3; i++)
        {
            customizedColors[0][i] = data.redCusomizedSaveData[i];
        }
        for (int i = 0; i < 3; i++)
        {
            customizedColors[1][i] = data.greenCusomizedSaveData[i];
        }
        for (int i = 0; i < 3; i++)
        {
            customizedColors[2][i] = data.blueCusomizedSaveData[i];
        }
    }
}
