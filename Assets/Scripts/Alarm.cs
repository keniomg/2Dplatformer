using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private AudioClip _alarmClip;

    private bool _isRogueInZone;
    private float _minimumAlarmVolume = 0;
    private float _maximumAlarmVolume = 1;
    private float _volumeChangeStep = 0.01f;

    private void Start()
    {
        _alarm.volume = _minimumAlarmVolume;
        _alarm.clip = _alarmClip;
        _alarm.loop = false;
    }

    private void Update()
    {
        ManageSignalizationVolume();
    }

    public void UpdateBurglaryStatus(bool isRogueInZone)
    {
        _isRogueInZone = isRogueInZone;
    }

    private void ManageSignalizationVolume()
    {
        if (_isRogueInZone)
        {
            if (_alarm.isPlaying == false)
            {
                _alarm.Play();
            }

            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _maximumAlarmVolume, _volumeChangeStep);
        }
        else
        {
            if (_alarm.volume == 0)
            {
                _alarm.Stop();
            }

            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _minimumAlarmVolume, _volumeChangeStep);
        }
    }
}