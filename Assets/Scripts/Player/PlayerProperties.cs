using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [SerializeField] private float _metersPerSecond;
    [SerializeField] private float _timeMultiplier;
    private float _distanceRan;
    private int _collectedCoins;
    private int _hitsToTake;
    private bool _isAlive;

    private void Awake()
    {
        _distanceRan = 0;
        _collectedCoins = 0;
        _isAlive = true;
    }

    private void FixedUpdate()
    {
        Debug.Log(GetDistance());
        if (_isAlive)
        {
            _timeMultiplier = Time.time * 0.002f; //Maak hier mogelijk een ternary operator van om een aantal mijlpalen te hebben waar de multiplier minder wordt

            _distanceRan += _metersPerSecond * _timeMultiplier;
        }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            _collectedCoins += 1;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _isAlive = (_hitsToTake > 0);
            _hitsToTake = _hitsToTake > 0 ? 0 : 1;
        }
    }
}