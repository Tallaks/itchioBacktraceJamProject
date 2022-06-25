using Game.Gameplay.Targets;
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
    }

    private void ConsumeAid(Target target)
    {
      target.GetComponent<TargetView>().ShowIsHelped();
      Destroy(gameObject);
    }
  }
}