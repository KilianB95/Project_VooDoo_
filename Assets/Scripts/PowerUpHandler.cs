using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private int _jumpMulitplier;

    private PowerUp _powerUp;
    private string _powerupTag;
    private float _powerupDuration;
    private bool _powerupActive = false;

    private void Awake()
    {
        _playerMovement = this.gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Time.time >= _powerupDuration && _powerupActive)
        {
            ReversePowerUp();
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
                    _playerMovement.SetJumpForce(_playerMovement.GetJumpForce() * _jumpMulitplier);
                    ManagePowerUpDuration(); //Zet automatisch de juiste duration in _powerupDuration
                    return;
            }
        }
    }

    private void ManagePowerUpDuration()
    {
        _powerupDuration = Time.time + _powerUp.GetDuration();
    }

    private void ReversePowerUp()
    {
        _powerupActive = false;
        switch (_powerupTag)
        {
            case "HeightPowerup":
                _playerMovement.SetJumpForce(_playerMovement.GetJumpForce() / _jumpMulitplier);
                return;
        }
    }

    public int GetJumpMultiplier()
    {
        return _jumpMulitplier;
    }
}