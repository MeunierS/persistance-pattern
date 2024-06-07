using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField]private TMP_Text volumeText;
    [SerializeField]private Toggle mouseState;

    private void Start(){
        SettingsData.Load();
        volumeText.text = $"Volume: {SettingsData.volume}";
        mouseState.isOn = SettingsData.inversedMouse;
    }

    public void BumpVolume(){
        SettingsData.BumpVolume();
        volumeText.text = $"Volume: {SettingsData.volume}";
    }
    public void InvertMouse(){
        SettingsData.InvertMouse();
    }
}
