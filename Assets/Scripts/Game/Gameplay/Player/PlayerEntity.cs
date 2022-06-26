using Game.Gameplay.Common;
using Game.Gameplay.States;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.StateMachine;
using Game.UI;
using UnityEngine;

namespace Game.Gameplay.Player
{
  [RequireComponent(typeof(Collider2D))]
  public class PlayerEntity : MonoBehaviour, IKillable
  {
    private StateMachine _stateMachine;

    private void Awake() => 
      _stateMachine = AllServices.Instance.Resolve<StateMachine>();

    private void OnTriggerEnter2D(Collider2D col)
    {
      if(col.GetComponent<PlayerKiller>())
        KillSelf();
    }

    public void KillSelf()
    {
      _stateMachine.NextState(new GameOverState(AllServices.Instance.Resolve<Mediator>()));
      Destroy(gameObject);
    }
  }
}