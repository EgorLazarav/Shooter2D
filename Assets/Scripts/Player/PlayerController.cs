using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] private float _movementSpeed = 5;
    [SerializeField] private int _startClipsCount = 5;
    [SerializeField] private Transform _weaponPoint;

    private PlayerCombat _combat;
    private PlayerMover _mover;
    private PlayerInput _input;

    public Weapon CurrentWeapon => _combat.CurrentWeapon;
    public int ClipsLeft => _combat.ClipsCount;

    public event Action Shoted;
    public event Action Reloaded;
    public event Action WeaponChanged;

    public void Init(Weapon startWeapon, BulletFactory bulletFactory)
    {
        _input = new PlayerInput();
        _input.Enable();

        startWeapon.Init(bulletFactory, _weaponPoint);
        _mover = new PlayerMover(transform, _movementSpeed);
        _combat = new PlayerCombat(startWeapon, _startClipsCount, _weaponPoint);

        WeaponChanged?.Invoke();
    }

    private void Update()
    {
        Vector2 inputDirection = GetInput();

        _mover.Move(inputDirection);
        _mover.RotateToMouse();

        if (_input.Combat.Shoot.IsInProgress())
        {
            if (_combat.TryShoot())
            {
                Shoted?.Invoke();
            }
        }

        if (_input.Combat.Reload.triggered)
        {
            if (_combat.TryReload())
            {
                StartCoroutine(ReloadingDelay());
            }
        }
    }

    private IEnumerator ReloadingDelay()
    {
        yield return new WaitForSeconds(_combat.CurrentWeapon.Data.ReloadTime);

        _combat.UseClip();
        Reloaded?.Invoke();
    }

    private Vector3 GetInput()
    {
        return _input.Movement.Move.ReadValue<Vector2>();
    }
}