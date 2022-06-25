using Backtrace.Unity;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.StateMachine;
using UnityEngine;

namespace Game.Infrastructure
{
  [RequireComponent(typeof(BacktraceClient), typeof(CoroutineRunner))]
  public class Bootstrapper : MonoBehaviour
  {
    private void Awake()
    {
      DontDestroyOnLoad(gameObject);
      AllServices.Initialize();
      AllServices.Instance.RegisterService(GetComponent<CoroutineRunner>());
      AllServices.Instance.RegisterService(new StateMachine(new BootState(AllServices.Instance.Resolve<CoroutineRunner>())));
    }
  }
}