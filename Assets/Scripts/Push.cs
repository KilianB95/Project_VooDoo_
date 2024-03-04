using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl)) 
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(-10, 0, 0);
        }
    }
}
