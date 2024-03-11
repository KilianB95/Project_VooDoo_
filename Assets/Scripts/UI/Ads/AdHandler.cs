using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdScript : MonoBehaviour
{
    private PlayerProperties _player;

    private GameObject _adImageObject;
    private Image _adImageSprite;
    [SerializeField] private Sprite[] _adImages;
    private bool _adActive;
    
    private float _adTimeLeft;
    [SerializeField] private float _adDuration;
    [SerializeField] private Slider _adDurationSlider;

    private void Awake()
    {
        _adActive = false;
        _adTimeLeft = 0;
        _adImageObject.SetActive(false);

        if (!_adImageObject)
            _adImageObject = GameObject.Find("Ad");

        if (!_player)
            _player = GameObject.Find("Player").GetComponent<PlayerProperties>();

        if(!_adDurationSlider)
            _adDurationSlider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        if (!_player.CheckIfAlive() && !_adActive) //Als speler doodgaat, activeer ad UI element en pak een willekeurige ad sprite
        {
            _adImageObject.SetActive(true);
            _adImageSprite.sprite = _adImages[Random.Range(0, _adImages.Length + 1)];
            _adTimeLeft = _adDuration;
            _adActive = true;
        }

        if (_adActive) //Wanneer een advertentie actief is
        {
            _adTimeLeft -= Time.deltaTime;
            _adDurationSlider.value = Mathf.InverseLerp(0, _adDuration, _adTimeLeft);
        }
            
        if (_adTimeLeft < 0 && _adActive) //Wanneer een advertentie actief is en de tijd om is
        {
            _player.SetIfAlive(true);
            _adImageObject.SetActive(false);
            _adActive = false;
        }
    }
}