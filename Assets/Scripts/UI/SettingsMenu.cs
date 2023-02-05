using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [Header("Volume Setting")]

    public AudioMixer audioMixer;
    [SerializeField] private TMP_Text volumeValueText = null;
    [SerializeField] private TMP_Text soundEffectValueText = null; 


    public void SetVolume (float volume)
    {
        // AudioListener.volume = volume;
        audioMixer.SetFloat("volume", volume);
        float volume_show = (float)((volume + 80) * 1.25);
        volumeValueText.text = volume_show.ToString("0");
    }

    public void SetVolumeEffect (float volumeEffect)
    {
        audioMixer.SetFloat("soundEffectVolume", volumeEffect);
        float volumeEffect_show = (float)((volumeEffect + 80) * 1.25);
        soundEffectValueText.text = volumeEffect_show.ToString("0");
    }
}
