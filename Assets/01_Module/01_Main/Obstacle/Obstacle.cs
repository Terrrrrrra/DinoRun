using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float _triggerPosX = -16;
    float _speed;

    internal void Init(float speed, Vector3 spawnPos)
    {
        _speed = speed;
        transform.position = spawnPos;
    }
    
    void Update()
    {
        Vector3 curVec = transform.localPosition;
        curVec.x -= _speed * Time.deltaTime;
        if (curVec.x < _triggerPosX) { Destroy(gameObject); }
        transform.localPosition = curVec;
    }
}
