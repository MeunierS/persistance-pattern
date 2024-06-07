using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsData
{
    public const string VOLUME_PREF = "volume";
    public const int VOLUME_DEFAULT = 10;
    public static int volume = VOLUME_DEFAULT;

    public const string MOUSE_PREF = "mouseMode";
    public const int MOUSE_DEFAULT = 1;
    public static bool inversedMouse = true; 

    public static void Load(){
        volume = PlayerPrefs.GetInt(VOLUME_PREF, VOLUME_DEFAULT);
        int tempValue = PlayerPrefs.GetInt(MOUSE_PREF, MOUSE_DEFAULT);;
        if(tempValue == 0){
            inversedMouse = false;
        }
    }

    public static void BumpVolume(){
        volume++;
        PlayerPrefs.SetInt(VOLUME_PREF, volume);
    }

    public static void InvertMouse(){
        if(inversedMouse){
            PlayerPrefs.SetInt(MOUSE_PREF, 1);
        }
        else{
            PlayerPrefs.SetInt(MOUSE_PREF, 0);
        }
    }
}
