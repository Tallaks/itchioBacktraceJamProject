using Extensions;
using Game.Gameplay.Common;
using Game.Gameplay.Player;
using UnityEngine;

namespace Game.Gameplay.Obstacles
{
  [RequireComponent(typeof(PlayerKiller))]
  public class Enemy : BaseObstacle
  {
    [SerializeField, Range(1,10)]
    private float _speed;

    private PlayerEntity _player;

    private void Awake() => 
      _player = FindObjectOfType<PlayerEntity>();

    private void Update()
    {
      if (transform.position.x < 7 && transform.position.x > _player.transform.position.x)
      {
        float yOffset = transform.position.y - _player.transform.position.y;
        transform.Translate(transform.position.SetY(Time.deltaTime * _speed * Mathf.Sign(yOffset)));
      }
    }
  }
}