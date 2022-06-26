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
      if (!target.isHelped)
      {
        target.Help();
        Score.Instance.AddFor(target);
      }
      Destroy(gameObject);
    }
  }
}