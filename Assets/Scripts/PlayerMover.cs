using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private float _speed = 3;

    public void Init(float speed)
    {
        _speed = speed;
    }

    public void Move(Vector2 direction)
    {
        Vector3 movePoint = transform.position + (Vector3)direction.normalized;
        transform.position = Vector2.MoveTowards(transform.position, movePoint, _speed * Time.deltaTime);
    }

    public void RotateToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 lookDirection = (mousePosition - transform.position).normalized;
        float rotationZ = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, rotationZ);
    }
}
