using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string username;
    public ScoreRecord leaderRecord;
    string savePath;

    void Awake() {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        savePath = Application.persistentDataPath + "/savefata.json";
        LoadGameData();
    }

    [System.Serializable]
    class SaveData {
        public string username;
        public ScoreRecord leaderRecord;
    }


    public void LoadGameData() {
        if (!File.Exists(savePath)) {
            return;
        }
        
        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        username = data.username;
        leaderRecord = data.leaderRecord;
    }

    public void SaveGameData() {
        SaveData data = new SaveData();
        data.username = username;
        data.leaderRecord = leaderRecord;
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
    }
}

[System.Serializable]
public class ScoreRecord
{
    public string username;
    public int score;
}