using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player player;

    public Color[] customizedColors = new Color[3];
    public int customizedPlayer = 1;

    public int currentLevelNumber = 1;

    //finished levels, moze i kao array myb al ovo je bolje jer sam uncertain, da ne moram stalno mijenjat
    public bool[] finishedLevels;


    //bas cool

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        customizedColors[0] = new Color(214 / 255.0f, 90 / 255.0f, 78 / 255.0f, 1);
        customizedColors[1] = new Color(159 / 255.0f, 226 / 255.0f, 136 / 255.0f, 1);
        customizedColors[2] = new Color(95 / 255.0f, 173 / 255.0f, 217 / 255.0f, 1);

        //set levels
        finishedLevels = new bool[currentLevelNumber];

        //temp
        finishedLevels[0] = true;
        finishedLevels[1] = true;
    }



    // handle game save data
    /*
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        player.currentColor = data.color;
        Vector3 position = new Vector3(data.position[0], data.position[1]);
        player.transform.position = position;
    }*/

}
