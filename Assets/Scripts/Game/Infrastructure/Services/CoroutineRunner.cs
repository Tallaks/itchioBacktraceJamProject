using UnityEngine;

namespace Game.Infrastructure.Services
{
  [RequireComponent(typeof(Bootstrapper))]
  public class CoroutineRunner : MonoBehaviour, IService
  {
  }
}