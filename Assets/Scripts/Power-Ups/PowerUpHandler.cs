using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpHandler : MonoBehaviour
{
    [SerializeField] private PlayerProperties _playerProperties;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private BombEffect _bomb;
    [SerializeField] private int _jumpMultiplier;
    [SerializeField] private Sprite _powerupNeutralSprite;
    [SerializeField] private ObjectPooling _bombPoo;

    private PowerUp _powerUp;
    private string _powerupTag;
    private bool _powerupActive = false;
    private float _powerupTimeLeft;
    private Image _powerupSpriteUI;
    [SerializeField] private Slider _powerupSlider;

    private void Awake()
    {
        if (!_playerProperties)
            _playerProperties = this.gameObject.GetComponent<PlayerProperties>();

        _playerMovement = this.gameObject.GetComponent<PlayerMovement>();
        _bomb = this.gameObject.GetComponent<BombEffect>();
        _powerupSlider = GameObject.Find("PowerupSlider").GetComponent<Slider>();
        _powerupSpriteUI = GameObject.Find("CenterArea").GetComponent<Image>();

        _powerupSlider.value = 0;
        _powerupSlider.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (_powerupTimeLeft > 0)
        {
            _powerupTimeLeft -= Time.deltaTime;
            _powerupSlider.value = Mathf.InverseLerp(0, _powerUp.GetDuration(), _powerupTimeLeft);
        }

        if (_powerupTimeLeft <= 0 && _powerupActive)
        {
            ReversePowerUp();
            _powerupSlider.gameObject.SetActive(false);
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Powerup")) //Dit moet vervangen worden met een check in de object pooling list
        {
            _powerUp = collision.gameObject.GetComponent<PowerUp>(); //Wanneer dit een powerup is, haal dan het PowerUp component op
            _powerupTag = _powerUp.tag;
            _powerupActive = true;
            switch (_powerupTag)
            {
                case "HeightPowerup":
                    _playerMovement.SetJumpForce(_playerMovement.GetJumpForce() * _jumpMultiplier);
                    ManagePowerUpDuration(); //Zet automatisch de juiste duration in _powerupDuration
                    _powerupSlider.gameObject.SetActive(true);
                    return;
                case "BombPowerup":
                    _bomb.SetBomb(true);
                    ManagePowerUpDuration();
                    _bombPoo.ReturnObstacle(collision.gameObject);
                    _powerupSlider.gameObject.SetActive(true);
                    return;
                case "HitPowerup":
                    _playerProperties.SetHits(1);
                    _powerupSlider.gameObject.SetActive(true);
                    return;
            }
        }
    }

    private void ManagePowerUpDuration()
    {
        _powerupTimeLeft = _powerUp.GetDuration();
        _powerupSpriteUI.sprite = _powerUp.GetIcon();
        _powerupSpriteUI.color = Color.white;
    }

    // HitPowerup hoeft niet omgedraaid te worden
    private void ReversePowerUp()
    {
        _powerupTimeLeft = 0;
        _powerupSpriteUI.sprite = _powerupNeutralSprite;
        _powerupSpriteUI.color = Color.black;
        _powerupActive = false;
        switch (_powerupTag)
        {
            case "HeightPowerup":
                _playerMovement.SetJumpForce(_playerMovement.GetJumpForce() / _jumpMultiplier);
                return;
            case "BombPowerup":
                _bomb.SetBomb(false);
                return;
        }
    }

    public int GetJumpMultiplier()
    {
        return _jumpMultiplier;
    }
}