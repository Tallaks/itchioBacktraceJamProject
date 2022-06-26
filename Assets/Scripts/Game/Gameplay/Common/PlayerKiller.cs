using UnityEngine;

namespace Game.Gameplay.Common
{
  [RequireComponent(typeof(Collider2D))]
  public class PlayerKiller : MonoBehaviour, IDestroyableIfInvisible
  {
  }
}