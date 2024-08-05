using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class DiamondsSpawner : MonoBehaviour
{
    [SerializeField] private Diamond _diamond;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private LayerMask _diamonds;

    private int _poolCapacity;
    private int _poolMaximumSize;
    private int _currentNonOccupiedSpawnPoint;
    private ObjectPool<Diamond> _pool;

    private void Awake()
    {
        _poolMaximumSize = _spawnPoints.Length;

        _pool = new ObjectPool<Diamond>(
            createFunc: () => Instantiate(_diamond),
            actionOnGet: (diamond) => AccompanyGet(diamond),
            actionOnRelease: (diamond) => AccompanyRelease(diamond),
            actionOnDestroy: (diamond) => Destroy(diamond),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaximumSize);
    }

    private void Start()
    {
        StartCoroutine(SpawnDiamonds());
    }

    private void AccompanyGet(Diamond diamond)
    {
        diamond.gameObject.SetActive(true);
        SetDiamondPosition(diamond);
        diamond.PickedUp += OnPickedUp;
    }

    private void AccompanyRelease(Diamond diamond)
    {
        diamond.gameObject.SetActive(false);
        diamond.PickedUp -= OnPickedUp;
    }

    private void SetDiamondPosition(Diamond diamond)
    {
        Vector2 spawnPosition = _spawnPoints[_currentNonOccupiedSpawnPoint].transform.position;
        diamond.transform.position = spawnPosition;
        diamond.SetPosition(spawnPosition);
    }

    private bool GetSpawnPointsOccupiedStatus()
    {
        float occupiedCheckRadius = _diamond.transform.localScale.x / 2;

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            bool isSpawnPointsOccupied = Physics2D.OverlapCircle(_spawnPoints[i].transform.position, occupiedCheckRadius, _diamonds);

            if (isSpawnPointsOccupied == false)
            {
                _currentNonOccupiedSpawnPoint = i;
                return false;
            }
        }

        return true;
    }

    private IEnumerator SpawnDiamonds()
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

    private IEnumerator WaitAnimationDuration(float animationDuration, Diamond diamond)
    {
       WaitForSeconds waitForSeconds = new(animationDuration);
       yield return waitForSeconds;
       _pool.Release(diamond);
    }

    private void OnPickedUp(Diamond diamond)
    {
        StartCoroutine(WaitAnimationDuration(diamond.GetDisappearAnimationDuration(), diamond));
    }
}