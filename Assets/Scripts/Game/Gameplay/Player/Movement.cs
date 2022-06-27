using Extensions;
using Game.Infrastructure.Services;
using Game.Infrastructure.Services.Factory;
using Game.Infrastructure.Services.StateMachine;
using UnityEngine;

namespace Game.Gameplay.Player
{
  [RequireComponent(typeof(PlayerEntity))]
  [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
  public class Movement : MonoBehaviour
  {
    private const float LeftXBorder = -9;
    private const float RightXBorder = 8.5f;
    private const float UpperBorder = 5f;

    [SerializeField, Range(0.1f, 50f)]
    private float _movementSpeed;
    
    private float MinX =>
      LeftXBorder + GetComponent<Collider2D>().bounds.extents.x;
    private float MaxX =>
      RightXBorder - GetComponent<Collider2D>().bounds.extents.x;
    private float MaxY =>
      UpperBorder - GetComponent<Collider2D>().bounds.extents.x;
    private float MinY =>
      RightXBorder - GetComponent<Collider2D>().bounds.extents.x;

    private Rigidbody2D _rigidbody;
    private bool _movingAllowed;

    private void Awake()
    {
      _movingAllowed = false;
      _rigidbody = GetComponent<Rigidbody2D>();
      _rigidbody.gravityScale = 0;
      
      AllServices.Instance.Resolve<StateMachine>();
      AllServices.Instance.Resolve<CoroutineRunner>();
      AllServices.Instance.Resolve<ObstacleFactory>();
      AllServices.Instance.Resolve<TargetFactory>();
    }

    private void Update()
    {
      if(_movingAllowed)
        transform.Translate((Vector2.right * Input.GetAxis("Horizontal")  + Vector2.up * Input.GetAxis("Vertical")) 
                            * _movementSpeed * Time.deltaTime);
      
      ClampPosition();
    }

    private void ClampPosition()
    {
      if (transform.position.x < MinX)
        transform.position = transform.position.SetX(MinX);
      if (transform.position.x > MaxX)
        transform.position = transform.position.SetX(MaxX);
      if (transform.position.y > MaxY)
        transform.position = transform.position.SetY(MaxY);
    }

    public void StartMoving()
    {
      _movingAllowed = true;
      _rigidbody.gravityScale = 1;
    }
  }
}