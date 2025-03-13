using System;
using System.Collections;
using UnityEngine;
using Zenject;


public class Weapon : MonoBehaviour
{
    [field: SerializeField] public WeaponData Data { get; private set; }

    [SerializeField] private Transform _shootPoint;
    
    private int _bulletsLeft;

    private Coroutine _shootDelayingCoroutine;
    private Coroutine _reloadingCoroutine;
    private BulletFactory _bulletFactory;

    public int BulletsLeft => _bulletsLeft;

    public void Init(BulletFactory bulletFactory, Transform weaponPoint)
    {
        transform.parent = weaponPoint;
        transform.localPosition = Data.PositionOffset;
        transform.localEulerAngles = Vector3.zero;
        GetComponent<SpriteRenderer>().sprite = Data.Sprite;

        _bulletFactory = bulletFactory;
        _bulletsLeft = Data.ClipCapacity;

        print("init");
    }

    public bool TryShoot()
    {
        if (_shootDelayingCoroutine != null || _reloadingCoroutine != null || _bulletsLeft == 0)
            return false;

        Bullet bullet = _bulletFactory.Get();
        bullet.Init(_shootPoint);

        _bulletsLeft--;

        _shootDelayingCoroutine = StartCoroutine(ShootDelaying());

        return true;
    }

    private IEnumerator ShootDelaying()
    {
        float baseDelay = 100;

        yield return new WaitForSeconds(baseDelay / Data.FireRate);

        _shootDelayingCoroutine = null;
    }

    public bool TryReload()
    {
        if (_reloadingCoroutine != null)
            return false;

        _reloadingCoroutine = StartCoroutine(Reloading());

        return true;
    }

    private IEnumerator Reloading()
    {
        yield return new WaitForSeconds(Data.ReloadTime);

        _reloadingCoroutine = null;

        _bulletsLeft = Data.ClipCapacity;
    }
}