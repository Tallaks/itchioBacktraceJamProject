using Game.Application.GameScore;
using Game.Gameplay.Common;
using UnityEngine;

namespace Game.Gameplay.Player
{
  [RequireComponent(typeof(Collider2D))]
  public class PlayerEntity : MonoBehaviour, IKillable
  {
    public CurrentScore Score { get; private set; }

    private void Awake() => 
      Score = new CurrentScore();

    private void OnTriggerEnter2D(Collider2D col)
    {
      if(col.GetComponent<PlayerKiller>())
        KillSelf();
    }

    public void KillSelf() => 
      Destroy(gameObject);
  }
}