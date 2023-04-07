using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool[] levelsFinished = new bool[10];
    public int customizedPlayerSaveData;

    public float[] redCusomizedSaveData = new float[3];
    public float[] greenCusomizedSaveData = new float[3];
    public float[] blueCusomizedSaveData = new float[3];

    public PlayerData(GameManager_new gMan)
    {
        for(int i = 0; i < 10; i++)
        {
            levelsFinished[i] = gMan.levelsCompleted[i];
        }

        customizedPlayerSaveData = gMan.customizedPlayer;

        for (int i = 0; i < 3; i++)
        {
            redCusomizedSaveData[i] = gMan.customizedColors[0][i];
        }
        for (int i = 0; i < 3; i++)
        {
            greenCusomizedSaveData[i] = gMan.customizedColors[1][i];
        }
        for (int i = 0; i < 3; i++)
        {
            blueCusomizedSaveData[i] = gMan.customizedColors[2][i];
        }
    }
}
