using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class InteractiveObjectsSpawner<Object> : MonoBehaviour where Object : InteractiveObject
{
    [SerializeField] protected Object InteractiveObject;
    [SerializeField] protected Transform[] SpawnPoints;
    [SerializeField] protected LayerMask InteractiveObjects;

    protected int PoolCapacity;
    protected int PoolMaximumSize;
    protected int CurrentNonOccupiedSpawnPoint;
    protected ObjectPool<Object> Pool;

    protected virtual void Awake()
    {
        PoolMaximumSize = SpawnPoints.Length;
        PoolCapacity = 2;
        PoolMaximumSize = 5;

        Pool = new ObjectPool<Object>(
            createFunc: () => Instantiate(InteractiveObject),
            actionOnGet: (interactiveObject) => AccompanyGet(interactiveObject),
            actionOnRelease: (interactiveObject) => AccompanyRelease(interactiveObject),
            actionOnDestroy: (interactiveObject) => Destroy(interactiveObject),
            collectionCheck: true,
            defaultCapacity: PoolCapacity,
            maxSize: PoolMaximumSize);
    }

    protected virtual void Start()
    {
        StartCoroutine(SpawnObject());
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
        Vector2 spawnPosition = SpawnPoints[CurrentNonOccupiedSpawnPoint].transform.position;
        interactiveObject.transform.position = spawnPosition;
    }

    protected bool GetSpawnPointsOccupiedStatus()
    {
        float occupiedCheckRadius = InteractiveObject.transform.localScale.x / 2;

        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            bool isSpawnPointsOccupied = Physics2D.OverlapCircle(SpawnPoints[i].transform.position, occupiedCheckRadius, InteractiveObjects);

            if (isSpawnPointsOccupied == false)
            {
                CurrentNonOccupiedSpawnPoint = i;
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
                Pool.Get();
            }

            yield return waitForSeconds;
        }
    }

    protected IEnumerator ReturnObjectToPool(float animationDuration, Object interactiveObject)
    {
        WaitForSeconds waitForSeconds = new(animationDuration);
        yield return waitForSeconds;
        Pool.Release(interactiveObject);
    }

    protected void OnPickedUp(Object interactiveObject)
    {
        StartCoroutine(ReturnObjectToPool(interactiveObject.GetDisappearAnimationDuration(), interactiveObject));
    }
}