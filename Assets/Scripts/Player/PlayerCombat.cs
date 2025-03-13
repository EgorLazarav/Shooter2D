using System;
using UnityEngine;

public class PlayerCombat
{
    private Weapon _currentWeapon;
    private int _clipsCount;
    private Transform _weaponPoint;

    public Weapon CurrentWeapon => _currentWeapon;
    public int ClipsCount => _clipsCount;

    public PlayerCombat(Weapon startWeapon, int clipsCount, Transform weaponPoint)
    {
        _currentWeapon = startWeapon;
        _clipsCount = clipsCount;
        _weaponPoint = weaponPoint;
    }

    public bool TryShoot()
    {
        return _currentWeapon.TryShoot();
    }

    public bool TryReload()
    {
        if (_clipsCount == 0)
            return false;

        return _currentWeapon.TryReload();
    }

    public void UseClip()
    {
        _clipsCount--;
    }
}
