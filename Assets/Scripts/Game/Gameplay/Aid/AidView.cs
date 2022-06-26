using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Aid
{
  public class AidView : MonoBehaviour
  {
    [SerializeField, Required] private ParticleSystem _breakParticles;
    [SerializeField, Required] private SpriteRenderer _renderer;
    
    public void Break()
    {
      _renderer.DOFade(0, 1);
      _breakParticles.Play();
    }
  }
}