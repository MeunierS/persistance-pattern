using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UIElements;
using JetBrains.Annotations;
public class PlayerData
{
    public const string DATA_PATH= "playerData.dat";
    public static string SAVE_PATH{
        get{return $"{Application.persistentDataPath}/{DATA_PATH}"; }
    }
    [Serializable] private struct SaveData {
        public float[]floatPosition;
        public float[]floatDestination;

        public Vector3 GetVector3(float x, float y, float z){
            return new Vector3(x, y, z);
        }
    }
    public static void Save(float[] pos, float[] dest){
        BinaryFormatter bf = new();
        FileStream file = File.Create(SAVE_PATH);
        
        SaveData sd = new();
        sd.floatPosition = pos;
        sd.floatDestination = dest;

        bf.Serialize(file, sd);
        file.Close();
        Debug.Log($"Data saved at {SAVE_PATH}.");
    }

    public static Vector3 Load(){
        if(File.Exists(SAVE_PATH)){
            BinaryFormatter bf = new();
            FileStream file = File.OpenRead(SAVE_PATH);

            SaveData sd = (SaveData) bf.Deserialize(file);
            file.Close();
            return null;
            //! 
            //Vector3 position = GetVector3(sd.floatPosition[0], sd.floatPosition[1], sd.floatPosition[2]);
            //return position;

            // position = sd.position;
            // destination = sd.destination;
        }
        else{
            Debug.Log($"File{SAVE_PATH} does not exists.");
            return Vector3.zero;
        }
    }
    public float[]floatPosition;
    public float[]floatDestination;
}
