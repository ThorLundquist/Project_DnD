using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public PlayerStatistics savedPlayerData = new PlayerStatistics();

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public PlayerStatistics LocalCopyOfData;
    public bool IsSceneLoaded = false;
    public void SaveData()
    {
        if (!Directory.Exists("Saves"))
        {
            Directory.CreateDirectory("Saves");
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create("Saves/save.binary");

        LocalCopyOfData = PlayerState.Instance.localPlayerData;

        formatter.Serialize(saveFile, LocalCopyOfData);

        saveFile.Close();
    }

    public void LoadData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open("Saves/save.binary", FileMode.Open);

        LocalCopyOfData = (PlayerStatistics)formatter.Deserialize(saveFile);
        SceneManager.LoadScene(LocalCopyOfData.SceneID);
        saveFile.Close();
    }
}
