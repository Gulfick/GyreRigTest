using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnerModel : MonoBehaviour
{
    [SerializeField] private CubeSpawnerView _view;
    [SerializeField] private GameObject _cubeEntity;
    [SerializeField] private Transform _entityParent;
    [SerializeField] private float _spawnInterval = 5, _speed = 1, _distance = 10;
    
    private HashSet<CubeEntity> _entitySet;
    private HashSet<CubeEntity> _entityDestroySet;
    private float _lastSpawnTime;
    private Coroutine _spawnCoroutine;
    private void Awake()
    {
        _view.Initialize(ChangeSpawnInterval, ChangeSpeed, ChangeDistance, new []{_spawnInterval, _speed, _distance});
        _entitySet = new HashSet<CubeEntity>();
        _entityDestroySet = new HashSet<CubeEntity>();
        _lastSpawnTime = -_spawnInterval;
        _spawnCoroutine = StartCoroutine(SpawnCube());
    }

    private void Update()
    {
        foreach (var entity in _entitySet)
        {
            entity.OnUpdate();
        }

        if (_entityDestroySet.Count == 0) 
            return;
        
        foreach (var entity in _entityDestroySet)
            DestroyEntity(entity);
        
        _entityDestroySet.Clear();
    }

    private void ChangeSpawnInterval(string value)
    {
        ChangeProperty(value, ref _spawnInterval);
        StopCoroutine(_spawnCoroutine);
        _spawnCoroutine = StartCoroutine(SpawnCube());
    }
    
    private void ChangeSpeed(string value)
    {
        ChangeProperty(value, ref _speed);
    }
    
    private void ChangeDistance(string value)
    {
        ChangeProperty(value, ref _distance);
    }

    private void ChangeProperty(string value, ref float property)
    {
        if (!float.TryParse(value, out var num))
        {
            Debug.LogError("Not a num");
            return;
        }

        property = num;
    }

    private IEnumerator SpawnCube()
    {
        var timeLeft = _lastSpawnTime + _spawnInterval - Time.time;
        yield return new WaitForSeconds(timeLeft);
        while (true)
        {
            var entity = Instantiate(_cubeEntity, _entityParent).GetComponent<CubeEntity>();
            _entitySet.Add(entity);
            entity.Initialize(_distance, _speed, MarkDestroyEntity);
            _lastSpawnTime = Time.time;
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void DestroyEntity(CubeEntity entity)
    {
        _entitySet.Remove(entity);
        Destroy(entity.gameObject);
    }
    
    private void MarkDestroyEntity(CubeEntity entity)
    {
        _entityDestroySet.Add(entity);
    }
}
