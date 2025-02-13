using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _fruitPrefab;
    [SerializeField] private Vector2 _worldBoundsMin;
    [SerializeField] private Vector2 _worldBoundsMax;
    [SerializeField] private int _numFruit = 100;

    private List<GameObject> _fruits;

    private void Start () {
        _fruits = new List<GameObject>();

        for(int i = 0; i < _numFruit; i++)
        {
            float x = UnityEngine.Random.Range(_worldBoundsMin.x, _worldBoundsMax.x);
            float y = UnityEngine.Random.Range(_worldBoundsMin.y, _worldBoundsMax.y);

            GameObject fruit = Instantiate(_fruitPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
            _fruits.Add(fruit);
        }
    }

    private void OnDrawGizmos () {
        Gizmos.color = Color.red;

        Vector3 center = new Vector3 (
            (_worldBoundsMax.x + _worldBoundsMin.x) / 2.0f,
            (_worldBoundsMax.y + _worldBoundsMin.y) / 2.0f,
            0
        );

        Vector3 size = new Vector3(
            Mathf.Abs(_worldBoundsMax.x - _worldBoundsMin.x),
            Mathf.Abs(_worldBoundsMax.y - _worldBoundsMin.y),
            0
        );

        Gizmos.DrawWireCube(center, size);
    }
}
