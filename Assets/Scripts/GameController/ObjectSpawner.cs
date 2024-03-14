using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPosition;
    [SerializeField] private ObjectPooling[] _objectPool;

    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;
    private float _timeToSpawn;
    private float _timeSinceSpawn;

    private void Start()
    {
        for (int i = 0; i < _spawnPosition.Length; i++) //Pakt alle objects met de naam "ObjectSpawner0", "ObjectSpawner1", "ObjectSpawner2", etc.
        {
            _spawnPosition[i] = GameObject.Find("ObjectSpawner" + i);
        }
    }

    // Om de zoveel secondes (kan je zelf instellen hoeveel secondes) spawned hij een obstakel.
    private void Update()
    {
        _timeSinceSpawn += Time.deltaTime;

        if (_timeSinceSpawn >= _timeToSpawn)
        {
            switch (Random.Range(0, 100))
            {
                //case < 60:

            }
            GameObject newObstacle = _objectPool[1].GetObstacle(); //VERANDER!!!!
            newObstacle.transform.position = _spawnPosition[Random.Range(0, _spawnPosition.Length)].transform.position;
            _timeToSpawn = Random.Range(_minSpawnTime, _maxSpawnTime);
            _timeSinceSpawn = 0f;
        }
    }
}
