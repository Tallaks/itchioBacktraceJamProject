using Game.Gameplay.Common;
using UnityEngine;

namespace Game.Gameplay.Player
{
  [RequireComponent(typeof(Collider2D))]
  public class PlayerEntity : MonoBehaviour, IKillable
  {
    private void OnTriggerEnter2D(Collider2D col)
    {
      if(col.GetComponent<PlayerKiller>())
        KillSelf();
    }

    public void KillSelf() => 
      Destroy(gameObject);
  }
}