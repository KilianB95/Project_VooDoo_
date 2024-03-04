using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PowerUpHandler))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRB;

    [SerializeField] private Vector3 _jumpForce;
    private Vector3 _jumpForceMax;
    private bool _isGrounded = true;

    private PowerUpHandler _powerupHandler;

    private void Awake()
    {
        _powerupHandler = this.gameObject.GetComponent<PowerUpHandler>();
        _playerRB = this.gameObject.GetComponent<Rigidbody>();
        _jumpForceMax = _jumpForce * _powerupHandler.GetJumpMultiplier();
    }

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

        if (_jumpForce.y > _jumpForceMax.y) //Zet een limiet aan jumpforce
        {
            _jumpForce.y = _jumpForceMax.y;
        }
    }
}
