using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _duration;

    private AudioSource _alarmSound;
    private float _runningTime;
    private float _normilizeRunningTime;
    private float _currentVolume;

    private void Awake()
    {
        _alarmSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            var alarm = StartCoroutine(ChangeValueAlarm(1f));
            _alarmSound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            var alarm = StartCoroutine(ChangeValueAlarm(0f));
            if (_currentVolume == 0f)
                _alarmSound.Stop();
        }
    }

    private IEnumerator ChangeValueAlarm(float targetVolume)
    {
        _runningTime = 0;
        while (_currentVolume != targetVolume)
        {
            _runningTime += Time.deltaTime;
            _normilizeRunningTime = _runningTime / _duration;
            _currentVolume = _alarmSound.volume;

            _alarmSound.volume = Mathf.MoveTowards(_currentVolume, targetVolume, _normilizeRunningTime * Time.deltaTime);

            yield return null;
        }
    }
}