using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    //PowerUp Types maken, haal uit PowerUp.cs, zet dan _powerUpType naar het juiste type en dan kan je ReversePowerUp() maken.
    //Als het spawnalgoritme het toelaat kan evt een UnityEvent deze waardes meegegeven worden.
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private int _jumpMulitplier;
    [SerializeField] private float _powerupDuration;
    private PowerUp _powerUp;

    private void Awake()
    {
        _playerMovement = this.gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (!_powerUp && Time.time >= _powerupDuration)
        {
            //Zet hier ReversePowerUp()
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Powerup")) //Dit moet vervangen worden met een check in de object pooling list
        {
            _powerUp = collision.gameObject.GetComponent<PowerUp>(); //Wanneer dit een powerup is, haal dan het PowerUp component op
            switch (collision.gameObject.tag)
            {
                case "HeightPowerup":
                    _playerMovement.SetJumpForce(_playerMovement.GetJumpForce() * _jumpMulitplier);
                    ManagePowerUpDuration(); //Zet automatisch de juiste duration in _powerupDuration
                    return;
            }

            _powerUp = null;
        }
    }

    private void ManagePowerUpDuration()
    {
        _powerupDuration = Time.time + _powerUp.GetDuration();
    }
}