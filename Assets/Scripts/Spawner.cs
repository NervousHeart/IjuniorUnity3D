using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] _points;
    [SerializeField] float _timeBetweenSpawns;
    [SerializeField] GameObject _objectToSpawn;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var spawn = StartCoroutine(Spawn(5));
        }
    }

    private IEnumerator Spawn(int countToSpawn)
    {
        var waitTime = new WaitForSeconds(_timeBetweenSpawns);
        for (int i = 0; i < countToSpawn; i++)
        {
            Instantiate(_objectToSpawn, _points[Random.Range(0, _points.Length)]);
            yield return waitTime;
        }
    }
}
