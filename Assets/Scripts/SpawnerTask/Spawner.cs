using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _prefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var spawn = StartCoroutine(Spawn(5));
        }
    }

    private IEnumerator Spawn(int amount)
    {
        var waitTime = new WaitForSeconds(_delay);
        for (int i = 0; i < amount; i++)
        {
            Instantiate(_prefab, _points[Random.Range(0, _points.Length)]);
            yield return waitTime;
        }
    }
}
