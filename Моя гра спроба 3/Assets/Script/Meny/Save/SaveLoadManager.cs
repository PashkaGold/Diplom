using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private string saveFilePath;

    private void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/gamedata.save";
    }

    public void SaveGame(GameData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream file = new FileStream(saveFilePath, FileMode.Create))
        {
            formatter.Serialize(file, data);
        }
        Debug.Log("Game saved to " + saveFilePath);
    }

    public GameData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream(saveFilePath, FileMode.Open))
            {
                return (GameData)formatter.Deserialize(file);
            }
        }
        else
        {
            Debug.LogWarning("Save file not found");
            return new GameData();
        }
    }
}
