using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _duration;

    private AudioSource _sound;
    private float _runningTime;
    private float _normilizeRunningTime;
    private float _currentVolume;

    private void Awake()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            var alarm = StartCoroutine(ChangeVolume(1f));
            _sound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            var alarm = StartCoroutine(ChangeVolume(0f));
        }
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        _runningTime = 0;
        while (_currentVolume != targetVolume)
        {
            _runningTime += Time.deltaTime;
            _normilizeRunningTime = _runningTime / _duration;
            _currentVolume = _sound.volume;

            _sound.volume = Mathf.MoveTowards(_currentVolume, targetVolume, _normilizeRunningTime * Time.deltaTime);

            yield return null;
        }
        if (_currentVolume == 0f)
            _sound.Stop();
    }
}