using System.Linq;
using UnityEngine;

namespace Game.Gameplay.Common
{
  public class DestroySpawnedObj : MonoBehaviour
  {
    public void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.GetComponent<Component>().GetType().GetInterfaces().Contains(typeof(IDestroyableIfInvisible)))
        Destroy(collision.gameObject);
    }
  }
}