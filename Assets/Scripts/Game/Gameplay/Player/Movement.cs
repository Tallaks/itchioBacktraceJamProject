using Extensions;
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

    private void Awake() => 
      _rigidbody = GetComponent<Rigidbody2D>();

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

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
  }
}