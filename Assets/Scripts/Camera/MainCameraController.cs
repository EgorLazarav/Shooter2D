using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    private Transform _followTarget;

    public void Init(Transform followTarget)
    {
        _followTarget = followTarget;

        StartCoroutine(Following());
    }

    private IEnumerator Following()
    {
        while (true)
        {
            if (_followTarget == null)
                yield break;

            Vector3 newPosition = _followTarget.position;
            newPosition.z = -10;
            transform.position = newPosition;   
            

            yield return null;
        }
    }
}

// 1. XRay
// 2. Camera Boundaries