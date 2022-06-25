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

    [SerializeField, Range(0.1f, 50f)]
    private float _movementSpeed;
    
    [SerializeField, Range(1, 15)]
    private float _jumpForce;

    private float MinX =>
      LeftXBorder + GetComponent<Collider2D>().bounds.extents.x;

    private float MaxX =>
      RightXBorder - GetComponent<Collider2D>().bounds.extents.x;

    private Rigidbody2D _rigidbody;
    private bool _movingAllowed;
    
    private StateMachine _stateMachine;
    private CoroutineRunner _coroutineRunner;
    private ObstacleFactory _obstacleFactory;
    private TargetFactory _targetFactory;

    private void Awake()
    {
      _movingAllowed = false;
      _rigidbody = GetComponent<Rigidbody2D>();
      _rigidbody.gravityScale = 0;
      
      _stateMachine = AllServices.Instance.Resolve<StateMachine>();
      _coroutineRunner = AllServices.Instance.Resolve<CoroutineRunner>();
      _obstacleFactory = AllServices.Instance.Resolve<ObstacleFactory>();
      _targetFactory = AllServices.Instance.Resolve<TargetFactory>();
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
      {
        if(_movingAllowed)
          _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        else
          _stateMachine.NextState(new GameLoopState(_coroutineRunner, _obstacleFactory, _targetFactory));
      }
      if(_movingAllowed)
        transform.Translate(Vector2.right * _movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
      ClampXPosition();
    }

    private void ClampXPosition()
    {
      if (transform.position.x < MinX)
        transform.position = transform.position.SetX(MinX);
      if (transform.position.x > MaxX)
        transform.position = transform.position.SetX(MaxX);
    }

    public void StartFalling()
    {
      _movingAllowed = true;
      _rigidbody.gravityScale = 1;
    }
  }
}