using System.Collections;
using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _clipCapacity = 30;
    [SerializeField] private int _bulletsLeft = 30;

    private Coroutine _shootDelayingCoroutine;
    private BulletFactory _bulletFactory;

    [Inject]
    public void Construct(BulletFactory bulletFactory)
    {
        _bulletFactory = bulletFactory;
    }

    public void Shoot()
    {
        if (_shootDelayingCoroutine != null)
            return;

        Bullet bullet = _bulletFactory.Get();
        bullet.Init(_shootPoint);

        _shootDelayingCoroutine = StartCoroutine(ShootDelaying());
    }

    private IEnumerator ShootDelaying()
    {
        yield return new WaitForSeconds(0.5f);

        _shootDelayingCoroutine = null;
    }

    private void reold()
    {
        if (_clipCapacity == 0)
        {
            _clipCapacity =_clipCapacity + _bulletsLeft;
        }
    }
    private IEnumerator Reold()
    {
        yield return new WaitForSeconds(2f);

        _shootDelayingCoroutine = null;
    }
}