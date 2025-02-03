using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Weapon _currentWeapon;

    public void Init(Weapon startWeapon)
    {
        _currentWeapon = startWeapon;
    }

    public void Shoot()
    {
        _currentWeapon.Shoot();
    }

    public void Reload()
    {
        _currentWeapon.Reload();
    }
}
