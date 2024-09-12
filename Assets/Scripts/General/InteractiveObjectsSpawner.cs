using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class InteractiveObjectsSpawner : MonoBehaviour
{
    [SerializeField] protected InteractiveObject InteractiveObject;
    [SerializeField] protected Transform[] SpawnPoints;
    [SerializeField] protected LayerMask InteractiveObjects;

    protected int PoolCapacity;
    protected int PoolMaximumSize;
    protected int CurrentNonOccupiedSpawnPoint;
    protected ObjectPool<InteractiveObject> Pool;

    protected virtual void Awake()
    {
        PoolMaximumSize = SpawnPoints.Length;
        PoolCapacity = 2;
        PoolMaximumSize = 5;

        Pool = new ObjectPool<InteractiveObject>(
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

    protected virtual void AccompanyGet(InteractiveObject interactiveObject)
    {
        interactiveObject.gameObject.SetActive(true);
        SetObjectPosition(interactiveObject);
        interactiveObject.PickedUp += OnPickedUp;
    }

    protected virtual void AccompanyRelease(InteractiveObject interactiveObject)
    {
        interactiveObject.gameObject.SetActive(false);
        interactiveObject.PickedUp -= OnPickedUp;
    }

    protected void SetObjectPosition(InteractiveObject interactiveObject)
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

    protected IEnumerator ReturnObjectToPool(float animationDuration, InteractiveObject interactiveObject)
    {
        WaitForSeconds waitForSeconds = new(animationDuration);
        yield return waitForSeconds;
        
        if (interactiveObject.gameObject.active)
        {
            Pool.Release(interactiveObject);
        }
    }

    protected void OnPickedUp(InteractiveObject interactiveObject)
    {
        StartCoroutine(ReturnObjectToPool(interactiveObject.GetDisappearAnimationDuration(), interactiveObject));
    }
}