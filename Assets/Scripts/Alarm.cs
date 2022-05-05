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
    private float _targetVolume;

    private void Awake()
    {
        _alarmSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _alarmSound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _alarmSound.Stop();
        }
    }



    private void Update()
    {
        ChangeValueAlarm();
    }

    private void ChangeValueAlarm()
    {
        _runningTime += Time.deltaTime;
        _normilizeRunningTime = _runningTime / _duration;
        _currentVolume = _alarmSound.volume;

        if (_currentVolume == 0)
        {
            _runningTime = 0f;
            _targetVolume = 1f;
        }
        else if (_currentVolume == 1f)
        {
            _runningTime = 0f;
            _targetVolume = 0f;
        }

        _alarmSound.volume = Mathf.MoveTowards(_currentVolume, _targetVolume, _normilizeRunningTime * Time.deltaTime);

        Debug.Log(_normilizeRunningTime);
    }

}
