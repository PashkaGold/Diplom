using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    private Dictionary<string, bool> objectStates = new Dictionary<string, bool>();

    public void SaveGame()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Saveable");
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                objectStates[obj.name] = obj.activeSelf;
            }
        }
        PlayerPrefs.SetString("ObjectStates", JsonUtility.ToJson(objectStates));
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("ObjectStates"))
        {
            objectStates = JsonUtility.FromJson<Dictionary<string, bool>>(PlayerPrefs.GetString("ObjectStates"));
            foreach (KeyValuePair<string, bool> kvp in objectStates)
            {
                GameObject obj = GameObject.Find(kvp.Key);
                if (obj != null)
                {
                    obj.SetActive(kvp.Value);
                }
            }
        }
    }
}
