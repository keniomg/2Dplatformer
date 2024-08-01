using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DiamondsSpawner : MonoBehaviour
{
    [SerializeField] private Diamond _diamond;
    [SerializeField] private Transform[] _spawnPoints;

    private int _poolCapacity;
    private int _poolMaximumSize;
    private ObjectPool<Diamond> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Diamond>(
            createFunc: () = Instantiate(_diamond),
            actionOnGet: (diamond) => AccompanyGet(),
            actionOnRelease: (diamond) => AccompanyRelease(),
            actionOnDestroy: (diamond) => Destroy(diamond),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaximumSize);
    }

    private void AccompanyGet()
    {

    }

    private void AccompanyRelease()
    {

    }
}
