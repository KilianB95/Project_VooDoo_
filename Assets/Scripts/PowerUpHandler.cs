using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    private PowerUp _powerUp;

    private void OnCollisionEnter(Collision collision)
    {
        _powerUp = collision.gameObject.GetComponent<PowerUp>();
        switch (_powerUp.name)
        {
            case "ExtraHeight": //Testnaam, voeg hier de veranderingen voor de Player Character toe
                Debug.Log("Extra height power up");
                return;
        }
    }
}