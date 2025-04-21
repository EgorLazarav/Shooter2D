using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private AIPath _aiPath;
    [SerializeField] private AIDestinationSetter _destinationSetter;

    [field: SerializeField] public float Max { get; private set; }

    public float Current { get; private set; }

    private PlayerController _player;

    public void Init(PlayerController player)
    {
        _player = player;

        _aiPath.canSearch = true;
        _aiPath.canMove = true;

        Current = Max;

        _destinationSetter.target = _player.transform;
    }

    public void ApplyDamage(float value)
    {
        Current -= value;

        if (Current <= 0)
            gameObject.SetActive(false);
    }

    private void FollowPlayer()
    {
        Transform target = FindObjectOfType<PlayerController>().transform;

        if (target == null)
            return;

        _aiPath.destination = target.position;

        /*
        if (_aiPath.hasPath == false || _aiPath.reachedEndOfPath)
        {
            _aiPath.SearchPath();
        }
        */
    }
}
