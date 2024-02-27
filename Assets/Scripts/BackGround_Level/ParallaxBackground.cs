using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private float _lenght, _startPos;
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _parralaxEffect;

    private void Start()
    {
        _startPos = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float distance = (_camera.transform.position.x * _parralaxEffect);

        transform.position = new Vector3(_startPos + distance, transform.position.y, transform.position.z);
    }
}
