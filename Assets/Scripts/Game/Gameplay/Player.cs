using UnityEngine;

namespace Game.Gameplay
{
  [RequireComponent(typeof(Rigidbody2D))]
  public class Player : MonoBehaviour
  {
    private Rigidbody2D _rigidbody;
    
    [SerializeField, Range(0.1f, 100f)]
    private float _movementSpeed;
    
    [SerializeField, Range(5, 15)]
    private float _jumpForce;

    private void Awake() => 
      _rigidbody = GetComponent<Rigidbody2D>();

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
      {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
      }

      transform.Translate(Vector2.right * _movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
    }
  }
}