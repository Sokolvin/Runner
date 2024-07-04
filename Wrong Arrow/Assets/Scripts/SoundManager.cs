using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public Slider volumeSlider;

    private const string VolumePrefsKey = "Volume";

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(VolumePrefsKey, 1f);
        audioSource.volume = savedVolume;
        volumeSlider.value = savedVolume;


        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    private void UpdateVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(VolumePrefsKey, volume);
        PlayerPrefs.Save();
    }
}
