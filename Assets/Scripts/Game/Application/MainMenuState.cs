using Game.Infrastructure.Services;
using Game.Infrastructure.Services.StateMachine;
using Game.UI;
using UnityEngine;

namespace Game.Application
{
  public class MainMenuState : IState
  {
    public void Enter() => 
      AllServices.Instance.RegisterService(Object.FindObjectOfType<Mediator>());

    public void Exit()
    {
    }
  }
}