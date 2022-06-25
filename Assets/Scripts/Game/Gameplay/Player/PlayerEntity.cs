using UnityEngine;

namespace Game.Gameplay.Player
{
  public class PlayerEntity : MonoBehaviour, IKillable
  {
    public void Kill() => 
      Destroy(gameObject);
  }
}