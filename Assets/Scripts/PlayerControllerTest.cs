using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;
    private Animator _animator;

    [SerializeField] private float speed;

    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity;

    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;

    [SerializeField] private float jumpPower;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) Move();
        else
        {
            _input = Vector2.zero;
            _direction = Vector3.zero;
            _animator.SetFloat("Speed", 0);
        }

        if (Input.GetButton("Jump")) Jump();
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
    }

    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
            _animator.SetBool("IsJumping", false);
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }

        _direction.y = _velocity;
    }

    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;

        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
    }

    private void ApplyMovement()
    {
        _characterController.Move(_direction * speed * Time.deltaTime);
    }

    public void Move()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");
        _direction = new Vector3(_input.x, 0.0f, _input.y);
        float _valueSpeed;

        if (Mathf.Abs(_input.x) > Mathf.Abs(_input.y))
        {
            _valueSpeed = Mathf.Abs(_input.x);
        }
        else
        {
            _valueSpeed = Mathf.Abs(_input.y);
        }

        _animator.SetFloat("Speed", _valueSpeed*5);
        Debug.Log(_animator.GetFloat("Speed"));
    }

    public void Jump()
    {
        if (!IsGrounded()) return;

        _velocity += jumpPower;

        _animator.SetBool("IsJumping", true);
        
    }

    private bool IsGrounded() => _characterController.isGrounded;
}