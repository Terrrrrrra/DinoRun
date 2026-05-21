using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Obstacle _cactusAPrefab;
    float _hurdle = 3;
    float _count = 0;

    void Update()
    {
        if (_player.IsDead) { return; }
        _count += Time.deltaTime;
        if (_hurdle < _count)
        {
            _count = 0;
            Obstacle curObstacle = Instantiate(_cactusAPrefab);
            curObstacle.Init(5, new Vector3(10, -2.5f, 0));
        }
    }
}
