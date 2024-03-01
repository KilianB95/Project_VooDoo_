using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PowerUpHandler))]
public class BombEffect : MonoBehaviour
{
    private bool _hasBomb;

    private void Update()
    {
        if (_hasBomb && Input.GetKey(KeyCode.LeftControl))
        {
            ThrowBomb();
        }
    }

    public void SetBomb(bool tempBomb)
    {
        _hasBomb = tempBomb;
    }

    public bool GetBomb()
    {
        return _hasBomb;
    }

    private void ThrowBomb()
    {
        // TODO:
        // Gooi een bom met een boog, object pooling onnodig want er is maar 1 bom per keer die herbruikt kan worden.

        _hasBomb = false;
    }
}
