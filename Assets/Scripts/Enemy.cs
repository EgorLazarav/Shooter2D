using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] private float _speed = 5;

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

    private void FollowPlayer()
    {
        Transform target = FindObjectOfType<PlayerController>().transform;
    }
}
