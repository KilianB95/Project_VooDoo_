using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(-10, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(10, 0, 0);
        }


    }
}
