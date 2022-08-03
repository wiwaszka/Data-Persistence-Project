using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public static PlayerName Instance;

    public int bestScorePoints = 0;
    public string bestPlayer;
    public string currentPlayer;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerNameAndScore();

    }

    [System.Serializable]
    class SaveData
    {
        public int bestScorePoints;
        public string bestPlayer;
    }

    public void SavePlayerNameAndScore()
    {
        SaveData data = new SaveData();
        data.bestScorePoints = bestScorePoints;
        data.bestPlayer = bestPlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerNameAndScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScorePoints = data.bestScorePoints;
            bestPlayer = data.bestPlayer;
        }
    }

    
}
