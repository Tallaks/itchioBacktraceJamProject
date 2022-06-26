using System.Collections;
using UnityEngine;

namespace Game.Gameplay.Aid
{
  [RequireComponent(typeof(Rigidbody2D))]
  public class AidMovement : MonoBehaviour
  {
    public void BalanceGravity() => 
      StartCoroutine(BalanceGravityRoutine());

    public void Stop() => 
      GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    private IEnumerator BalanceGravityRoutine()
    {
      while (GetComponent<Rigidbody2D>().gravityScale > 0)
      {
        GetComponent<Rigidbody2D>().gravityScale -= Time.deltaTime;
        yield return null;
      }      
    }
  }
}