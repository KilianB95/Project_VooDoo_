using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturner : MonoBehaviour
{
    private ObjectPooling _objectPool;

    private void Start()
    {
        _objectPool = FindObjectOfType<ObjectPooling>();
    }

    // Als de object de collider aanraakt begint het script in objectpooling en dan wordt 't object false gamaakt.
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        if (_objectPool != null)
            _objectPool.ReturnObstacle(other.gameObject);
    }
}
