using Game.Gameplay.Targets;
using UnityEngine;
using Game.Gameplay.Common;

namespace Game.Gameplay.Player
{
  [RequireComponent(typeof(Collider2D))]
  public class Aid : MonoBehaviour
  {
    private PlayerEntity _player;

    private void OnTriggerEnter2D(Collider2D col)
    {
      var target = col.GetComponent<Target>();
      if (target != null) 
        ConsumeAid(target);
      if (col.gameObject.GetComponent<PlayerKiller>())
        Destroy(gameObject);
    }


        public void Attach(PlayerEntity player) => 
      _player = player;

    private void ConsumeAid(Target target)
    {
      _player.Score.AddFor(target);
      var targetView = target.GetComponent<TargetView>();
      if(!targetView.isHelped)
           targetView.ShowIsHelped();
      Destroy(gameObject);
    }
  }
}