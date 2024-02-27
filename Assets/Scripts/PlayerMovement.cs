using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRB;
    [SerializeField] private Vector3 _jumpForce;
    private bool _isGrounded = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _playerRB.AddForce(_jumpForce);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isGrounded && collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }

    public Vector3 GetJumpForce()
    {
        return _jumpForce;
    }

    public void SetJumpForce(Vector3 tempForce)
    {
        _jumpForce = tempForce;
    }
}
