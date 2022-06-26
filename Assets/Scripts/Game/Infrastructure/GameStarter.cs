using Game.Gameplay.States;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.Factory;
using Game.Infrastructure.Services.StateMachine;
using Game.UI;
using UnityEngine;

namespace Game.Infrastructure
{
  public class GameStarter : MonoBehaviour
  {
    private StateMachine _stateMachine;
    private Mediator _mediator;

    private void Awake()
    {
      _stateMachine = AllServices.Instance.Resolve<StateMachine>();
      _mediator = AllServices.Instance.Resolve<Mediator>();
    }

    private void Update()
    {
      if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) 
        StartGame();
    }

    private void StartGame()
    {
      _stateMachine.NextState(new GameLoopState());
      Destroy(gameObject);
    }
  }
}