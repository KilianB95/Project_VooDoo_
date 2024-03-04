using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _powerupDuration;
    [SerializeField] private Sprite _powerupIcon;

    public float GetDuration()
    {
        return _powerupDuration;
    }

    public Sprite GetIcon()
    {
        return _powerupIcon;
    }
}