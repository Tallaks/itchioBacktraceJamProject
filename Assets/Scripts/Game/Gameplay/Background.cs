using UnityEngine;

namespace Game.Gameplay
{
  [RequireComponent(typeof(Sprite))]
  public class Background : MonoBehaviour
  {
    [SerializeField]
    private float _xPositionToResetPosition = -4;
    
    private Vector3 _startPosition;

    private void Awake() => 
      _startPosition = transform.position;

    private void Update()
    {
      if (transform.position.x < _xPositionToResetPosition) 
        transform.position = _startPosition;
    }
  }
}