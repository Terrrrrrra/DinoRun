using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Rigidbody2D _rd;
    PlayerInput _playerInput;

    [SerializeField] float _jumpPower;
    bool _canJump;
    bool _isDead;
    internal bool IsDead { get { return _isDead; } }
    internal event Action OnDead;

    void Start()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _canJump = true;
        //_rd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_isDead) { return; }
        if (_canJump && _playerInput.Player.Jump.WasPressedThisFrame())
        {
            //점프하는구간
            _canJump = false;
            _rd.AddForce(new Vector2(0, _jumpPower), ForceMode2D.Impulse); // Force도 있음
            _animator.SetTrigger("Jump");
            _animator.SetBool("JumpEnd", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _canJump = true;
        _animator.SetBool("JumpEnd", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isDead) { return; }
        if (collision.tag == "Obstacle")
        {
            _animator.SetTrigger("Dead");
            _isDead = true;
            OnDead?.Invoke();
        }
    }
}
