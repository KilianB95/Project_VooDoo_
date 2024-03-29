using UnityEngine;
using UnityEngine.UI;
using TMPro;

//script is gelinked aan de empty object "SoundValue"
public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider _volumeSetting;
    [SerializeField] private TMP_Text _volumeTextUI;

    private void Start()
    {
        _volumeSetting.onValueChanged.AddListener(SaveVolume);
        LoadVolume();
    }

    public void VolumeSliderController(float volume) => _volumeTextUI.text = volume.ToString("100.0");
    
    // deze functie zorgt er voor dat de value dat verandered is met de slider word opgeslagen in een playerpref
    private void SaveVolume(float volume)
    {
        float volumeValue = _volumeSetting.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadVolume();
    }

    //deze functie roept de opgslagen value op om te gebruiken voor de volume in de game
    private void LoadVolume()
    {
        var volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        _volumeSetting.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}

