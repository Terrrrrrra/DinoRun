using UnityEngine;

public class Rolling : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Transform[] _groundSpriteArr;
    [SerializeField] float _speed;
    [SerializeField] float _jumpDistance;
    [SerializeField] float _triggerPosX;

    private void Update()
    {
        if (_player.IsDead) { return; }
        for (int i = 0; i < _groundSpriteArr.Length; i++)
        {
            Vector3 curVec = _groundSpriteArr[i].localPosition;
            curVec.x -= _speed * Time.deltaTime;
            if (curVec.x < _triggerPosX) { curVec.x += _jumpDistance; }
            _groundSpriteArr[i].localPosition = curVec;
        }
    }
}
