using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover
{
    private float _movementSpeed = 3;
    private Transform _transform;

    public PlayerMover(Transform transform, float movementSpeed)
    {
        _transform = transform;
        _movementSpeed = movementSpeed;
    }

    public void Move(Vector2 direction)
    {
        Vector3 movePoint = _transform.position + (Vector3)direction.normalized;
        _transform.position = Vector2.MoveTowards(_transform.position, movePoint, _movementSpeed * Time.deltaTime);
    }

    public void RotateToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 lookDirection = (mousePosition - _transform.position).normalized;
        float rotationZ = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        _transform.eulerAngles = new Vector3(0, 0, rotationZ);
    }
}
