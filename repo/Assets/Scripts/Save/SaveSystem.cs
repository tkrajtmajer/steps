using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    // saving data
    public static void Save(GameManager_new gMan)
    {
        //static so you can call it from anywhere w/out instantiating!

        BinaryFormatter formatter = new BinaryFormatter();

        //path to directory that isnt gonna change
        string path = Application.persistentDataPath + "/LevelData.steps";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(gMan);

        formatter.Serialize(stream, data);
        stream.Close(); 
    }

    // loading data
    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "/LevelData.steps";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        } 
        else
        {
            //Debug.Log("save file not found in" + path);
            return null;
        }
    }

}
