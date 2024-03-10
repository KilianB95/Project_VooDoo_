using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{
    private PlayerProperties _player;
    [SerializeField] private float _timeToKill = 5f;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerProperties>();
    }

    private void FixedUpdate()
    {
        if (Time.time > _timeToKill)
        {
            _player.SetIfAlive(false);
            this.gameObject.GetComponent<KillScript>().enabled = false;
        }
    }
}
