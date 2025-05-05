using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private NavMeshAgent _agent;

    [field: SerializeField] public float Max { get; private set; }

    public float Current { get; private set; }

    private PlayerController _player;

    public void Init(PlayerController player)
    {
        _player = player;

        Current = Max;
    }

    public void ApplyDamage(float value)
    {
        Current -= value;

        if (Current <= 0)
            gameObject.SetActive(false);
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Transform target = FindObjectOfType<PlayerController>().transform;

        if (target == null)
            return;

        _agent.SetDestination(target.position);
        Vector3 curretRotation = transform.eulerAngles;
        curretRotation.x = 0;
        curretRotation.y = 0;
        transform.eulerAngles = curretRotation;
    }
}
