using Game.Gameplay.Player;
using Game.Gameplay.Targets;
using UnityEngine;

namespace Game.Gameplay.Common
{
  public class DestroySpawnedObj : MonoBehaviour
  {
    public void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.GetComponent<PlayerKiller>() ||
          collision.gameObject.GetComponent<Target>() ||
          collision.gameObject.GetComponent<Aid>())
        Destroy(collision.gameObject);
    }
  }
}