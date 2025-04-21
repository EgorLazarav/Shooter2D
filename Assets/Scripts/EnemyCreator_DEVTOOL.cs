using UnityEngine;

public class EnemyCreator_DEVTOOL : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private PlayerController _player;

    private void Update()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<PlayerController>();
            return;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Enemy enemy = Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);
            enemy.Init(_player);
        }
    }
}
