using Extensions;
using Game.Gameplay.Player;
using UnityEngine;

namespace Game.Infrastructure.Services.Factory
{
  public class AidFactory : AbstractFactory<Aid>
  {
    private PlayerEntity _player;

    public void AttachToPLayer(PlayerEntity playerEntity) => 
      _player = playerEntity;

    public override Aid Create()
    {
      var prefab = Resources.Load<GameObject>("Prefabs/Aid");
      var aid = Object.Instantiate(prefab, _player.transform.position.SetY(_player.transform.position.y - 0.5f),
        Quaternion.identity).GetComponent<Aid>();
      aid.Attach(_player);
      return aid;
    }
  }
}