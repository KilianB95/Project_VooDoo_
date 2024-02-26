using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "ExtraHeight": //Testnaam, voeg hier de veranderingen voor de Player Character toe
                return;
        }
    }
}