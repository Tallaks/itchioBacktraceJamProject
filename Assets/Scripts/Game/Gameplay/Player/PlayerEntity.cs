using Game.Application.GameScore;
using Game.Gameplay.Common;
using Game.Gameplay.States;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.StateMachine;
using UnityEngine;

namespace Game.Gameplay.Player
{
  [RequireComponent(typeof(Collider2D))]
  public class PlayerEntity : MonoBehaviour, IKillable
  {
    private StateMachine _stateMachine;
    public CurrentScore Score { get; private set; }

    private void Awake()
    {
      _stateMachine = AllServices.Instance.Resolve<StateMachine>();
      Score = new CurrentScore();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
      if(col.GetComponent<PlayerKiller>())
        KillSelf();
    }

    public void KillSelf()
    {
      _stateMachine.NextState(new GameOverState());
      Destroy(gameObject);
    }
  }
}