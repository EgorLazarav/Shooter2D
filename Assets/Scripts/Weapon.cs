using System.Collections;
using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;

    private Coroutine _reloadingCoroutine;
    private BulletFactory _bulletFactory;

    [Inject]
    public void Construct(BulletFactory bulletFactory)
    {
        _bulletFactory = bulletFactory;
    }

    public void Shoot()
    {
        if (_reloadingCoroutine != null)
            return;

        Bullet bullet = _bulletFactory.Get();
        bullet.Init(_shootPoint);

        _reloadingCoroutine = StartCoroutine(Reloading());
    }

    private IEnumerator Reloading()
    {
        yield return new WaitForSeconds(0.5f);

        _reloadingCoroutine = null;
    }
}