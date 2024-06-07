using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameData
{
    public const string DATA_PATH= "gameData.dat";
    public static string SAVE_PATH{
        get{return $"{Application.persistentDataPath}/{DATA_PATH}"; }
    }
    [Serializable] private class SaveData {
        public int score;
    }
    public static void Save()
    {
        BinaryFormatter bf = new();
        FileStream file = File.Create(SAVE_PATH);

        SaveData sd = new();
        sd.score = score;

        bf.Serialize(file, sd);
        file.Close();
        Debug.Log($"Data saved at {SAVE_PATH}.");
    }

    public static void Load(){
        if(File.Exists(SAVE_PATH)){
            BinaryFormatter bf = new();
            FileStream file = File.OpenRead(SAVE_PATH);

            SaveData sd = (SaveData) bf.Deserialize(file);
            file.Close();

            score = sd.score;
        }
        else{
            Debug.Log($"File{SAVE_PATH} does not exists.");
        }
    }
    public static int score = 0;

    public static void UpdateScore(int value){
        score=value;
    }
    public static void AddScore(int value) => UpdateScore(score + value);
    
}
