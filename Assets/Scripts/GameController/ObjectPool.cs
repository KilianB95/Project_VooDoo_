using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
     public static ObjectPool _sharedInstance;
     public List<GameObject> _objectPool;
     public GameObject _objectToPool;
     public int _poolAmount;

     void Awake()
    {
        _sharedInstance = this;
    }

     void Start()
    {
        _objectPool = new List<GameObject>();
        GameObject temporary;
        for(int i = 0; i < _poolAmount; i++)
        {
            temporary = Instantiate(_objectToPool);
            temporary.SetActive(false);
            _objectPool.Add(temporary);
        }
    }

    public GameObject GetPooledObjects()
    {
        for(int i = 0; i < _poolAmount; i++)
        {
            if (!_objectPool[i].activeInHierarchy)
            {
                return _objectPool[i];
            }
        }
        return null;
    }
}

