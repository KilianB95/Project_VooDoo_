using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdScript : MonoBehaviour
{
    private GameObject _adImage;
    private PlayerProperties _player;
    private float _adTimeLeft;
    private bool _adActive;
    [SerializeField] private float _adDuration;
    [SerializeField] private Slider _adDurationSlider;

    private void Awake()
    {
        _adActive = false;

        _adTimeLeft = 0;
        if (!_adImage)
            _adImage = GameObject.Find("Ad");

        _adImage.SetActive(false);

        if (!_player)
            _player = GameObject.Find("Player").GetComponent<PlayerProperties>();

        if(!_adDurationSlider)
            _adDurationSlider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    private void FixedUpdate()
    {

        if (!_player.CheckIfAlive() && !_adActive) // Werkt niet (God haat mij)
        {
            _adImage.SetActive(true);
            _adTimeLeft = _adDuration;
            _adActive = true;
        }

        if (_adTimeLeft > 0 && _adActive)
        {
            _adTimeLeft -= Time.deltaTime;
            _adDurationSlider.value = Mathf.InverseLerp(0, _adDuration, _adTimeLeft);
        }
            
        if (_adTimeLeft < 0 && _adActive)
        {
            _player.SetIfAlive(true);
            _adImage.SetActive(false);
            _adActive = false;
        }

        // _adTimeLeft = (_adTimeLeft > 0) ? _adTimeLeft -= Time.deltaTime : _adTimeLeft;
    }
}
