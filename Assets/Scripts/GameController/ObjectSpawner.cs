using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPosition;
    [SerializeField] private ObjectPooling[] _objectPool;

    [SerializeField] private float _minObstacleSpawnTime;
    [SerializeField] private float _maxObstacleSpawnTime;
    [SerializeField] private float _minCoinSpawnTime;
    [SerializeField] private float _maxCoinSpawnTime;
    [SerializeField] private float _minPowerUpSpawnTime;
    [SerializeField] private float _maxPowerUpSpawnTime;
    private int _randomSpawnNumber;
    private float _timeToSpawn;
    private float _timeSinceSpawn;

    private void Start()
    {
        for (int i = 0; i < _spawnPosition.Length; i++) //Pakt alle objects met de naam "ObjectSpawner0", "ObjectSpawner1", "ObjectSpawner2", etc.
        {
            _spawnPosition[i] = GameObject.Find("ObjectSpawner" + i); //0 = grond
        }
    }

    // Om de zoveel secondes (kan je zelf instellen hoeveel secondes) spawned hij een obstakel.
    private void Update()
    {
        _timeSinceSpawn += Time.deltaTime;

        if (_timeSinceSpawn >= _timeToSpawn)
        {
            _randomSpawnNumber = Random.Range(0, 100);
            switch (_randomSpawnNumber)
            {
                case int i when i > 0 && i <= 60: //Spawn voor muntjes
                    GameObject newObstacle = _objectPool[0].GetObstacle(); //Obstakels
                    newObstacle.transform.position = _spawnPosition[2].transform.position; //Alleen op de grond gespawned
                    _timeToSpawn = Random.Range(_minObstacleSpawnTime, _maxObstacleSpawnTime);
                    break;
                case int i when i > 60 && i <= 90:
                    GameObject newCoins = _objectPool[1].GetObstacle(); //Coins
                    newCoins.transform.position = _spawnPosition[Random.Range(0, _spawnPosition.Length)].transform.position;
                    _timeToSpawn = Random.Range(_minCoinSpawnTime, _maxCoinSpawnTime);
                    break;
                case int i when i > 90 && i <= 100:
                    GameObject newPowerUp = _objectPool[2].GetObstacle(); //Powerups
                    newPowerUp.transform.position = _spawnPosition[Random.Range(0, _spawnPosition.Length)].transform.position;
                    _timeToSpawn = Random.Range(_minPowerUpSpawnTime, _maxPowerUpSpawnTime);
                    break;
            }
            _timeSinceSpawn = 0f;
        }
    }
}
