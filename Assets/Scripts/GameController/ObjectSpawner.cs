using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;

    [SerializeField] private float _spawnTimer, _spawnCountDown;

    private void Start()
    {
        _spawnCountDown = _spawnTimer;
    }

    private void Update()
    {
        _spawnCountDown -= Time.deltaTime;

        if(_spawnCountDown < 0)
        {
            _spawnCountDown = Time.deltaTime;

            GameObject obstacle = ObjectPool._sharedInstance.GetPooledObjects();
            if(obstacle != null )
            {
                obstacle.transform.position = transform.position;
                obstacle.transform.rotation = transform.rotation;
                obstacle.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
