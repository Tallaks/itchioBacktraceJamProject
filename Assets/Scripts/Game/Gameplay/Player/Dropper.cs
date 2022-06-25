using UnityEngine;

namespace Game.Gameplay.Player
{
  [RequireComponent(typeof(PlayerEntity))]
  public class Dropper : MonoBehaviour
  {
    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
      }
    }
  }
}