using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _ñlip;
    [SerializeField] private ForbiddenZone _forbiddenZone;
    [SerializeField] private float _alarmStepDelay;

    private float _minimumVolume = 0;
    private float _maximumVolume = 1;
    private float _volumeChangeStep = 0.2f;
    private WaitForSeconds _waitForSeconds;

    private Coroutine _increaseCoroutine;
    private Coroutine _decreaseCoroutine;

    private void Start()
    {
        _waitForSeconds = new(_alarmStepDelay);
        _source.volume = _minimumVolume;
        _source.clip = _ñlip;
        _source.loop = false;
    }

    private void OnEnable()
    {
        _forbiddenZone.RogueEnteredZone += OnRogueEnteredZone;
        _forbiddenZone.RogueLeftZone += OnRogueLeftZone;
    }

    private void OnDisable()
    {
        _forbiddenZone.RogueEnteredZone -= OnRogueEnteredZone;
        _forbiddenZone.RogueLeftZone -= OnRogueLeftZone;
    }

    private void OnRogueEnteredZone()
    {
        if (_decreaseCoroutine != null)
        {
            StopCoroutine(_decreaseCoroutine);
            _decreaseCoroutine = null;
        }

        if (_increaseCoroutine == null)
        {
            _increaseCoroutine = StartCoroutine(IncreaseAlarmVolume());
        }
    }

    private void OnRogueLeftZone()
    {
        if (_increaseCoroutine != null)
        {
            StopCoroutine(_increaseCoroutine);
            _increaseCoroutine = null;
        }

        if (_decreaseCoroutine == null)
        {
            _decreaseCoroutine = StartCoroutine(DecreaseAlarmVolume());
        }
    }

    private IEnumerator IncreaseAlarmVolume()
    {
        while (_source.volume < _maximumVolume)
        {
            if (_source.isPlaying == false)
            {
                _source.Play();
            }

            _source.volume = Mathf.MoveTowards(_source.volume, _maximumVolume, _volumeChangeStep);
            yield return _waitForSeconds;
        }

        _increaseCoroutine = null;
    }

    private IEnumerator DecreaseAlarmVolume()
    {
        while (_source.volume > _minimumVolume)
        {
            if (_source.volume == 0)
            {
                _source.Stop();
            }

            _source.volume = Mathf.MoveTowards(_source.volume, _minimumVolume, _volumeChangeStep);
            yield return _waitForSeconds;
        }

        _decreaseCoroutine = null;
    }
}