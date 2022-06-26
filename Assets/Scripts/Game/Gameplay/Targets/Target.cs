using UnityEngine;

namespace Game.Gameplay.Targets
{
  [RequireComponent(typeof(Collider2D), typeof(TargetView))]
  public class Target : MonoBehaviour
  {
    [SerializeField] private int _scorePoints;

    private TargetView _view;
    public bool isHelped { get; private set; } = false;
    public int ScorePoint => _scorePoints;

    private void Awake() => 
      _view = GetComponent<TargetView>();

    public void Help()
    {
      isHelped = true;
      _view.ShowIsHelped();
    }
  }
}