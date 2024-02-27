using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider volumeSetting;
    [SerializeField] private Text volumeTextUI;

    private void Start()
    {
        volumeSetting.onValueChanged.AddListener(SaveVolume);
        LoadVolume();
    }

    // deze functie zorgt er voor dat de value dat verandered is met de slider word opgeslagen in een playerpref
    //zit nog een error in de ToString
    //scriptis nog niet gelinked
    public void VolumeSliderController() => volumeTextUI.text = volumeTextUI.ToString("100.0");

    private void SaveVolume(float volume)
    {
        float _volumeValue = volumeSetting.value;
        PlayerPrefs.SetFloat("VolumeValue", _volumeValue);
        LoadVolume();
    }

    //deze functie roept de opgslagen value op om te gebruiken voor de volume in de game
    private void LoadVolume()
    {
        var _volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSetting.value = _volumeValue;
        AudioListener.volume = _volumeValue;
    }
}
