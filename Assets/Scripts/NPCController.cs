using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private NavMeshAgent _agent;
    private Animator _animation;
    private Rigidbody _rigidBody;

    private bool _isJumping = false;
    private float jumpForce = 5.0f;
    private float jumpCooldown = 3.0f;
    private bool _isGrounded = true;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animation = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody>();

        if (_target != null)
        {
            _agent.SetDestination(_target.transform.position);
        }

        StartCoroutine(JumpRoutine());
    }

    private IEnumerator JumpRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(jumpCooldown);

            if (_isGrounded && !_isJumping)
            {
                PerformJump();
            }
        }
    }

    private void PerformJump()
    {
        _isJumping = true;
        _isGrounded = false;

        // Désactive temporairement le NavMeshAgent
        _agent.enabled = false;

        // Déclenche l'animation de saut
        _animation.SetBool("IsJumping", true);
        Debug.Log("Animation Jump started");

        // Applique une force verticale pour le saut
        _rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Réinitialise le saut après un délai
        Invoke(nameof(ResetJump), 1.0f);
    }

    private void ResetJump()
    {
        _isJumping = false;
        _animation.SetBool("IsJumping", false);

        // Corrige la position si le personnage est sous le sol
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 2.0f))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }

        // Réactive le NavMeshAgent
        _agent.enabled = true;

        // Repositionne l'agent sur le NavMesh
        _agent.Warp(transform.position);

        if (_target != null)
        {
            _agent.SetDestination(_target.transform.position);
        }

        Debug.Log("Jump reset and NavMeshAgent re-enabled");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private bool IsGrounded()
    {
        float rayLength = 1.1f;
        return Physics.Raycast(transform.position, Vector3.down, rayLength);
    }

    private void Update()
    {
        // Met à jour la vitesse pour l'animation
        if (_agent != null && _animation != null && _agent.enabled)
        {
            float speed = _agent.velocity.magnitude;
            _animation.SetFloat("Speed", speed);
        }

        // Vérifie si le personnage est sur le sol
        if (!IsGrounded() && !_isJumping)
        {
            _isGrounded = false;
        }
    }
}
