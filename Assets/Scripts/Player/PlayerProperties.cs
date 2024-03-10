using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BombEffect))]
[RequireComponent(typeof(PowerUpHandler))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerProperties : MonoBehaviour
{
    [SerializeField] private float _metersPerSecond;
    [SerializeField] private float _timeMultiplier;
    private float _distanceRan;
    private int _collectedCoins;
    private int _hitsToTake;
    private int _score;
    private int _highScore;
    private bool _isAlive;

    private void Awake()
    {
        _distanceRan = 0;
        _collectedCoins = 0;
        _hitsToTake = 0;
        _score = 0;
        _isAlive = true;
    }

    private void FixedUpdate()
    {
        if (_isAlive)
        {
            //Maak hier mogelijk een ternary operator van om een aantal mijlpalen te hebben waar de multiplier minder wordt. Misschien werken met parallax snelheid?
            _timeMultiplier = Time.time * 0.002f;

            _distanceRan += _metersPerSecond * _timeMultiplier;
        }

        if (!_isAlive)
            CalculateScore();
    }

    public float GetDistance()
    {
        return Mathf.RoundToInt(_distanceRan);
    }

    public int GetCoins()
    {
        return _collectedCoins;
    }

    public void SetHits(int tempHits)
    {
        _hitsToTake = tempHits;
    }

    public bool CheckIfAlive()
    {
        return _isAlive;
    }
    public void SetIfAlive(bool tempAlive)
    {
        _isAlive = tempAlive;
    }

    private void CalculateScore()
    {
        _score = (int) _distanceRan + (_collectedCoins * 10); //Mogelijk nog punten geven voor aantal Power-Ups opgepakt

        if (_score > _highScore)
            _highScore = _score;
    }

    private void OnCollisionEnter(Collision collision)
    {
      /*  if (collision.gameObject.CompareTag("Coin"))
            _collectedCoins++;

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _isAlive = (_hitsToTake > 0);

            if (_hitsToTake > 0)
                --_hitsToTake;
        } */
    }
}