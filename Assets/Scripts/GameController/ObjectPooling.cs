using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private Queue<GameObject> _obstaclePool = new Queue<GameObject>();
    [SerializeField] private int _poolStartSize = 150;  

    //Wanneer de game start maakt hij de hoeveelheid objecten aan doormiddel van de _poolStartSize.
    void Start()
    {
        for (int i = 0; i < _poolStartSize; i++)
        {
            GameObject obstacle = Instantiate(_obstaclePrefab);
            _obstaclePool.Enqueue(obstacle);
            obstacle.SetActive(false);
        }   
    }

    // Vanaf hier maakt die de objecten true en spawnen ze in.
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
            _obstaclePool.Enqueue(obstacle);
            obstacle.SetActive(true);
            return obstacle;
        }
    }

    //Als de object door de destbetreffende collision/collider gaat dan wordt t false en gaat terug in de queue.
    public void ReturnObstacle(GameObject collison)
    {
        _obstaclePool.Enqueue(collison);
        collison.SetActive(false);
    }
}
