using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpHandler : MonoBehaviour
{
    [SerializeField] private PlayerProperties _playerProperties;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private BombEffect _bomb;
    [SerializeField] private int _jumpMulitplier;
    [SerializeField] private Sprite _powerupNeutralSprite;

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
        //_powerupSlider = GameObject.Find("PowerupSlider").GetComponent<Slider>();
        //_powerupSpriteUI = GameObject.Find("CenterArea").GetComponent<Image>();
    }

    private void FixedUpdate()
    {

        if (_powerupTimeLeft > 0)
        {
            Debug.Log(_powerupTimeLeft);
            _powerupTimeLeft -= Time.deltaTime;
            _powerupSlider.value = Mathf.InverseLerp(0, _powerUp.GetDuration(), _powerupTimeLeft);
        }

        if (_powerupTimeLeft <= 0 && _powerupActive)
            ReversePowerUp();
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
                    _playerMovement.SetJumpForce(_playerMovement.GetJumpForce() * _jumpMulitplier);
                    ManagePowerUpDuration(); //Zet automatisch de juiste duration in _powerupDuration
                    return;
                case "BombPowerup":
                    _bomb.SetBomb(true);
                    ManagePowerUpDuration();
                    return;
                case "HitPowerup":
                    _playerProperties.SetHits(1);
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
                _playerMovement.SetJumpForce(_playerMovement.GetJumpForce() / _jumpMulitplier);
                return;
            case "BombPowerup":
                _bomb.SetBomb(false);
                return;
        }
    }

    public int GetJumpMultiplier()
    {
        return _jumpMulitplier;
    }
}