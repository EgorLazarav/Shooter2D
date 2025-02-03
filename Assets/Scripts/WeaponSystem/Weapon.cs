using System.Collections;
using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _clipCapacity = 30;
    [SerializeField] private float _fireRate = 100;
    [SerializeField] private float _reloadTime = 2;
    
    private int _bulletsLeft;

    private Coroutine _shootDelayingCoroutine;
    private Coroutine _reloadingCoroutine;
    private BulletFactory _bulletFactory;

    [Inject]
    public void Construct(BulletFactory bulletFactory)
    {
        _bulletFactory = bulletFactory;
        _bulletsLeft = _clipCapacity;
    }

    public void Shoot()
    {
        if (_shootDelayingCoroutine == null || _reloadingCoroutine != null || _bulletsLeft == 0)
            return;

        Bullet bullet = _bulletFactory.Get();
        bullet.Init(_shootPoint);
        _bulletsLeft--;

        _shootDelayingCoroutine = StartCoroutine(ShootDelaying());
    }

    private IEnumerator ShootDelaying()
    {
        float baseDelay = 100;

        yield return new WaitForSeconds(baseDelay / _fireRate);

        _shootDelayingCoroutine = null;
    }

    public void Reload()
    {
        _reloadingCoroutine = StartCoroutine(Reloading());
    }

    private IEnumerator Reloading()
    {
        yield return new WaitForSeconds(_reloadTime);

        _reloadingCoroutine = null;
        _bulletsLeft = _clipCapacity;
    }
}