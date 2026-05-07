using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rd;
    PlayerInput _playerInput;

    [SerializeField] float _jumpPower;

    void Start()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        //_rd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_playerInput.Player.Jump.WasPressedThisFrame())
        {
            _rd.AddForce(new Vector2(0, _jumpPower), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
    }
}
