using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private Queue<GameObject> _obstaclePool = new Queue<GameObject>();
    [SerializeField] private int _poolStartSize = 15;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _poolStartSize; i++)
        {
            GameObject obstacle = Instantiate(_obstaclePrefab);
            _obstaclePool.Enqueue(obstacle);
            obstacle.SetActive(false);
        }   
    }

    public GameObject GetObstacle()
    {
        if (_obstaclePool.Count > 0)
        {
            GameObject obstacle = _obstaclePool.Dequeue();
            obstacle.SetActive(true);
            return obstacle;
        }
        else
        {
            GameObject obstacle = Instantiate(_obstaclePrefab);
            return obstacle;
        }
    }

    public void ReturnObstacle(GameObject collison)
    { 
        collison.SetActive(false); 
    }
}
