using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string CurrentName;
        public string BestName;
        public int BestScore;
    }

    public static PersistenceManager Instance { get; private set; }
    public string CurrentName { get; set; }

    private string _bestName = "";
    private int _bestScore = 0;
    private readonly string _fileName = "savedata.json";

    public string GetBestScoreLine()
    {
        if (_bestName != "")
        {
            return $"{_bestName} : {_bestScore}";
        }
        else
        {
            return "—";
        }
    }

    public void SavePersistenceData(int score)
    {
        if (score > _bestScore)
        {
            _bestName = CurrentName;
            _bestScore = score;
        }
        SaveData savedata = new() {
            BestName = _bestName,
            BestScore = _bestScore,
            CurrentName = CurrentName
        };
        string json = JsonUtility.ToJson(savedata);
        File.WriteAllText(Application.persistentDataPath + $"/{_fileName}", json);
    }

    public void LoadPersistenceData()
    {
        string path = Application.persistentDataPath + $"/{_fileName}";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData savedata = JsonUtility.FromJson<SaveData>(json);
            _bestScore = savedata.BestScore;
            _bestName = savedata.BestName;
            CurrentName = savedata.CurrentName;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPersistenceData();
    }

}
