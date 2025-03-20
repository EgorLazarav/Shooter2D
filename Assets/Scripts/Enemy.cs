using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] private float _speed = 5;

    [field: SerializeField] public float Max { get; private set; }

    public float Current { get; private set; }

    private void Start()
    {
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
        Transform target = FindObjectOfType<PlayerController>().transform;

        if (target != null ) 
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * _speed);
    }
}
