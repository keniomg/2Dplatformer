using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class InteractiveObjectsSpawner<Object> : MonoBehaviour where Object : InteractiveObject
{
    [SerializeField] protected Object _interactiveObject;
    [SerializeField] protected Transform[] _spawnPoints;
    [SerializeField] protected LayerMask _interactiveObjects;

    protected int _poolCapacity;
    protected int _poolMaximumSize;
    protected int _currentNonOccupiedSpawnPoint;
    protected ObjectPool<Object> _pool;

    protected virtual void Awake()
    {
        _poolMaximumSize = _spawnPoints.Length;

        _pool = new ObjectPool<Object>(
            createFunc: () => Instantiate(_interactiveObject),
            actionOnGet: (interactiveObject) => AccompanyGet(interactiveObject),
            actionOnRelease: (interactiveObject) => AccompanyRelease(interactiveObject),
            actionOnDestroy: (interactiveObject) => Destroy(interactiveObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaximumSize);
    }

    protected virtual void Start()
    {
        StartCoroutine(SpawnObject());
        _poolCapacity = 2;
        _poolMaximumSize = 5;
    }

    protected virtual void AccompanyGet(Object interactiveObject)
    {
        interactiveObject.gameObject.SetActive(true);
        SetObjectPosition(interactiveObject);
    }

    protected virtual void AccompanyRelease(Object interactiveObject)
    {
        interactiveObject.gameObject.SetActive(false);
    }

    protected void SetObjectPosition(Object interactiveObject)
    {
        Vector2 spawnPosition = _spawnPoints[_currentNonOccupiedSpawnPoint].transform.position;
        interactiveObject.transform.position = spawnPosition;
    }

    protected bool GetSpawnPointsOccupiedStatus()
    {
        float occupiedCheckRadius = _interactiveObject.transform.localScale.x / 2;

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            bool isSpawnPointsOccupied = Physics2D.OverlapCircle(_spawnPoints[i].transform.position, occupiedCheckRadius, _interactiveObjects);

            if (isSpawnPointsOccupied == false)
            {
                _currentNonOccupiedSpawnPoint = i;
                return false;
            }
        }

        return true;
    }

    protected IEnumerator SpawnObject()
    {
        float spawnDelay = 2;
        WaitForSeconds waitForSeconds = new(spawnDelay);

        while (true)
        {
            if (GetSpawnPointsOccupiedStatus() == false)
            {
                _pool.Get();
            }

            yield return waitForSeconds;
        }
    }

    protected IEnumerator ReturnObjectToPool(float animationDuration, Object interactiveObject)
    {
        WaitForSeconds waitForSeconds = new(animationDuration);
        yield return waitForSeconds;
        _pool.Release(interactiveObject);
    }

    protected void OnPickedUp(Object interactiveObject)
    {
        StartCoroutine(ReturnObjectToPool(interactiveObject.GetDisappearAnimationDuration(), interactiveObject));
    }
}