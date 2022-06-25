using UnityEngine;

namespace Game.Gameplay.Common
{
  public class MovingLeftObject : MonoBehaviour
  {
    [SerializeField, Range(1, 100)] 
    private float _speed;

    private void Update() => 
      transform.Translate(Vector3.left * _speed * Time.deltaTime);

    public void StopMoving() => 
      _speed = 0;
  }
}