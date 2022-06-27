using System.Collections;
using Game.Application.GameScore;
using Game.Gameplay.Common;
using Game.Gameplay.Targets;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Aid
{
  [RequireComponent(typeof(Collider2D))]
  public class Aid : MonoBehaviour, IKillable, IDestroyableIfInvisible
  {
    [SerializeField, Required] private AidAudio _audio;
    [SerializeField, Required] private AidMovement _movement;
    [SerializeField, Required] private AidView _view;

    private void Awake()
    {
      //GetComponent<Animation>().Play();
      _movement.BalanceGravity();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
      var target = col.GetComponent<Target>();
      if (target != null)
        ConsumeAid(target);
      if (col.gameObject.GetComponent<PlayerKiller>()) 
        KillSelf();
    }
    
    private void ConsumeAid(Target target)
    {
      if (!target.isHelped)
      {
        target.Help();
        _audio.PlayConsumed();
        Score.Instance.AddFor(target);
      }

      GetComponent<SpriteRenderer>().enabled = false;
      GetComponent<Collider2D>().enabled = false;
      StartCoroutine(DelayedDestroy());
    }

    private IEnumerator DelayedDestroy()
    {
      yield return new WaitForSeconds(1);
      Destroy(gameObject);
    }

    public void KillSelf() => 
      StartCoroutine(KillRoutine());

    private IEnumerator KillRoutine()
    {
      _audio.PlayBreaking();
      _movement.Stop();
      _view.Break();
      Score.Instance.Decrease(50);
      gameObject.AddComponent<MovingLeftObject>();
      yield return new WaitForSeconds(1.1f);
      Destroy(gameObject);
    }
  }
}