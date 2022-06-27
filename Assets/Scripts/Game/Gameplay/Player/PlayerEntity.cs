using System;
using System.Collections;
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
    [SerializeField] private PlayerAudio _audio;
    
    private StateMachine _stateMachine;
    private Movement _movement;

    private void Awake()
    {
      _stateMachine = AllServices.Instance.Resolve<StateMachine>();
      _movement = GetComponent<Movement>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
      if(col.GetComponent<PlayerKiller>())
        KillSelf();
    }

    public void KillSelf()
    {
      _stateMachine.NextState(new GameOverState(AllServices.Instance.Resolve<Mediator>()));
      _audio.PlayExplosion();
      _movement.enabled = false;

      StartCoroutine(DelayedDestroy());
    }

    private IEnumerator DelayedDestroy()
    {
      yield return new WaitForSeconds(2);
      Destroy(gameObject);
    }
  }
}