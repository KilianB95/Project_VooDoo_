using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    // Geeft de speed aan van 't object en met wat voor snelheid het naar links gaat bewegen.
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }
}
