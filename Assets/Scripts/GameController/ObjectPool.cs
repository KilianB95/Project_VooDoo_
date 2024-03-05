using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
     public static ObjectPool _sharedInstance;
     [SerializeField] private List<GameObject> _objectPool;
     [SerializeField] private GameObject _objectToPool;
     [SerializeField] private int _poolAmount;

     void Awake()
    {
        _sharedInstance = this;
    }

    //Vanaf het begin voordat de game start worden de objecten buiten de scene geinstantieerd.
    //Ze staan op False en worden pas op true gezet wanneer hun functie wordt uitgevoerd.
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

    //De objecten worden zichtbaar in de hierachie en staan op false.
    //Plus doe hoeveelheid er is aangegeven hoeveel objecten er in moeten staan.
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

