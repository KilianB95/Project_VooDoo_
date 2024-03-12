using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private float _timeToSpawn = 5f;
    private float _timeSinceSpawn;
    private ObjectPooling _objectPool;

    private void Start()
    {
        _objectPool = FindObjectOfType<ObjectPooling>();
    }

    // Om de zoveel secondes(kan je zelf instellen hoeveel secondes) spawned hij een obstakel.
    private void Update()
    {
        _timeSinceSpawn += Time.deltaTime;
        if(_timeSinceSpawn >= _timeToSpawn)
        {
            GameObject newObstacle = _objectPool.GetObstacle();
            newObstacle.transform.position = this.transform.position;
            _timeSinceSpawn = 0f;
        }
    }
}
