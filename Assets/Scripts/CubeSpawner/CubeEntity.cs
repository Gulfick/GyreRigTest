using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEntity : MonoBehaviour
{
    private Transform _transform;
    private float _speed = 1;
    private float _endPoint;
    private Action<CubeEntity> OnEnd;

    public void Initialize(float distance, float speed, Action<CubeEntity> destroyAction)
    {
        _transform = transform;
        _endPoint = _transform.position.z + distance;
        _speed = speed;
        OnEnd += destroyAction;
    }

    public void OnUpdate()
    {
        _transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        if (_transform.position.z >= _endPoint)
            OnEnd?.Invoke(this);
    }
}
