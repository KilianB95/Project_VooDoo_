using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRB;

    [SerializeField] private Vector3 _jumpForce;
    private Vector3 _jumpForceMax;
    private bool _isGrounded = true;
    private Animator _animator;

    private PowerUpHandler _powerupHandler;

    private void Awake()
    {
        _powerupHandler = this.gameObject.GetComponent<PowerUpHandler>();
        _playerRB = this.gameObject.GetComponent<Rigidbody>();
        _jumpForceMax = _jumpForce * _powerupHandler.GetJumpMultiplier();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _playerRB.AddForce(_jumpForce);
            _isGrounded = false;
            if(_animator != null)
            {
                _animator.Play("JumpStart");
            }
        }

        if (!_isGrounded)
            Physics.gravity += new Vector3(0, -0.5f, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isGrounded && collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            Physics.gravity = new Vector3(0, -9.8f, 0);
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
            _jumpForce.y = _jumpForceMax.y;
    }
}
