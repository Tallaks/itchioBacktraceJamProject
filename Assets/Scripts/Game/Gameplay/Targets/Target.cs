using UnityEngine;

namespace Game.Gameplay.Targets
{
  [RequireComponent(typeof(Collider2D))]
  public class Target : MonoBehaviour
  {
    [SerializeField] private int _scorePoints;

    public int ScorePoint => _scorePoints;
  }
}