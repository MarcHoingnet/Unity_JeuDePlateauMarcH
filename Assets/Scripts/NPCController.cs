using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private NavMeshAgent _agent;
    private Animator _animation;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_target.transform.position);
        _animation = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_agent != null && _animation != null)
        {
            _animation.SetFloat("Speed", _agent.velocity.magnitude);
        }
    }
}

