using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider _volumeSetting;
    [SerializeField] private TMP_Text _volumeTextUI;

    private void Start()
    {
        _volumeSetting.onValueChanged.AddListener(SaveVolume);
        LoadVolume();
    }

    // deze functie zorgt er voor dat de value dat verandered is met de slider word opgeslagen in een playerpref
    //zit nog een error in de ToString
    //script is nog niet gelinked
    public void VolumeSliderController(float volume) => _volumeTextUI.text = volume.ToString("100.0");

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

