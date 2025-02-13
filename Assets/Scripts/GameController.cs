using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _fruitPrefab;
    [SerializeField] private Vector2 _worldBoundsMin;
    [SerializeField] private Vector2 _worldBoundsMax;
    [SerializeField] private int _numFruit = 100;

    private List<GameObject> _fruits = new List<GameObject>();
    int fruitNumber = 0;

    private void Awake ()
    {
        ResetGame();
    }

    private void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame();
        }
    }

    private void OnDrawGizmos ()
    {
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

    private void ResetGame ()
    {
        // destroy existing fruits
        foreach(GameObject fruit in _fruits)
        {
            Destroy(fruit);
        }
        _fruits.Clear();

        // add new fruits
        for(int i = 0; i < _numFruit; i++)
        {
            float x = UnityEngine.Random.Range(_worldBoundsMin.x, _worldBoundsMax.x);
            float y = UnityEngine.Random.Range(_worldBoundsMin.y, _worldBoundsMax.y);

            GameObject fruit = Instantiate(_fruitPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
            fruit.name = "Fruit " + fruitNumber;
            fruitNumber++;

            _fruits.Add(fruit);
        }

        // reset player location
        Capybara.Instance.ResetLocation();
    }
}
