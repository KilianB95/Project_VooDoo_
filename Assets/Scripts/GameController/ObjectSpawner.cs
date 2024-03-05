using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;

    [SerializeField] private float _spawnTimer, _spawnCountDown;

    //Dit is de countdown voordat er een entitie wordt ingespawned.
    private void Start()
    {
        _spawnCountDown = _spawnTimer;
    }

    //Wanneer de countdown 0 is worden de obstacles ingespawned.
    //Nadat ze ingespawned zijn komen zij op de locatie waar de spawner is ingesteld
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

    //Als de obstacle door de collision heeft met de collider wordt het object op false gezet.
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
