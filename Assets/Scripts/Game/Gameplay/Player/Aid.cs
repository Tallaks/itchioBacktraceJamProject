using Game.Gameplay.Targets;
using UnityEngine;

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
    }

    public void Attach(PlayerEntity player) => 
      _player = player;

    private void ConsumeAid(Target target)
    {
      _player.Score.AddFor(target);
      target.GetComponent<TargetView>().ShowIsHelped();
      Destroy(gameObject);
    }
  }
}