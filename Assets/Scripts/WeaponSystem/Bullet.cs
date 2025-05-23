using System.Collections;
using UnityEngine;
using Zenject.SpaceFighter;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy = 3f;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private Rigidbody2D _rigidbody;

    public void Init(Transform parent)
    {
        gameObject.SetActive(true);

        transform.parent = parent;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.parent = null;

        _rigidbody.velocity = transform.right * _speed;
        StartCoroutine(DelayingDeactivate());
    }

    private IEnumerator DelayingDeactivate()
    {
        yield return new WaitForSeconds(_timeToDestroy);

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IHealth health))
        {
            health.ApplyDamage(1);
        }

        gameObject.SetActive(false);
    }
}

