using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Image _gameoverImage;
    
    void Start()
    {
        _player.OnDead += () => { _gameoverImage.gameObject.SetActive(true); };
    }

}
