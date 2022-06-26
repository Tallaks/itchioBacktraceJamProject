using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Targets
{
  [RequireComponent(typeof(Target))]
  [RequireComponent(typeof(Collider2D))]
  public class TargetView : MonoBehaviour
  {
    [SerializeField, Required] private SpriteRenderer _spriteRenderer;
    
    public void ShowIsHelped() => 
      _spriteRenderer.color = Color.gray;
  }
}