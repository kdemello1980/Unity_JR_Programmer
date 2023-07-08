using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // we don't need the Start() or Update()

    public static MainManager Instance;
    public Color TeamColor;

    public void Awake()
    {
        // The very first time that you launch the Menu scene, no MainManager will have filled the Instance variable. 
        // This means it will be null, so the condition will not be met, and the script will continue as you previously 
        // wrote it.  However, if you load the Menu scene again later, there will already be one MainManager in existence, 
        // so Instance will not be null. In this case, the condition is met: the extra MainManager is destroyed and the script 
        // exits there.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    // System.Serializable allows the class to be serialized into JSON.
    // Why are you creating a class and not giving the MainManager instance
    // directly to the JsonUtility? Well, most of the time you won’t save everything
    // inside your classes. It’s good practice and more efficient to use a small class
    // that only contains the specific data that you want to save.
    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;       
    }

    // Save the color to a file to persist in between sessions.
    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // Load the color from the file to persist in between sessions.
    public void LoadColor()
    {    
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // Set the color
            TeamColor = data.TeamColor;
        }
    }
    
}
