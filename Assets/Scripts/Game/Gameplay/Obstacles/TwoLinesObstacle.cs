using Extensions;
using Game.Gameplay.Common;
using UnityEngine;

namespace Game.Gameplay.Obstacles
{
  public class TwoLinesObstacle : BaseObstacle
  {
    [SerializeField] private PlayerKiller _upperRect;
    [SerializeField] private PlayerKiller _lowerRect;
    
    public void SetDistanceBetweenRects(float distance)
    {
      _upperRect.transform.position = _upperRect.transform.position.SetY(distance / 2);
      _lowerRect.transform.position = _lowerRect.transform.position.SetY(-distance / 2);
    }
  }
}