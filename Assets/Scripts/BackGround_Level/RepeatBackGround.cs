using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    Vector3 _startPosition;
    float _repeatWidth;
    private void Start()
    {
        _startPosition = transform.position;
        _repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    private void Update()
    {
        if (transform.position.x < _startPosition.x - _repeatWidth)
            transform.position = _startPosition;
    }

}
