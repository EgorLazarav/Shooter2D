using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerCombat _combat;

    [Header("CONFIG")]
    [SerializeField] private Weapon _startWeapon;
    [SerializeField] private float _movementSpeed = 5;

    private PlayerInput _input;

    private void Start()
    {
        _input = new PlayerInput();
        _input.Enable();

        _mover.Init(_movementSpeed);
        _combat.Init(_startWeapon);
    }

    private void Update()
    {
        Vector2 inputDirection = GetInput();

        _mover.Move(inputDirection);
        _mover.RotateToMouse();

        if (_input.Combat.Shoot.IsInProgress())
        {
            _combat.Shoot();
        }

        if (_input.Combat.Reload.triggered)
        {
            _combat.Reload();
        }
    }

    private Vector3 GetInput()
    {
        return _input.Movement.Move.ReadValue<Vector2>();
    }
}