using Game.Application.GameScore;
using Game.Gameplay.Targets;
using Game.Gameplay.Common;
using UnityEngine;

namespace Game.Gameplay.Player
{
  [RequireComponent(typeof(Collider2D))]
  public class Aid : MonoBehaviour
  {
    private void OnTriggerEnter2D(Collider2D col)
    {
      var target = col.GetComponent<Target>();
      if (target != null)
        ConsumeAid(target);
      if (col.gameObject.GetComponent<PlayerKiller>())
        Destroy(gameObject);
    }
    
    private void ConsumeAid(Target target)
    {
      Score.Instance.AddFor(target);
      
      var targetView = target.GetComponent<TargetView>();
      if (!targetView.isHelped)
        targetView.ShowIsHelped();
      Destroy(gameObject);
    }
  }
}