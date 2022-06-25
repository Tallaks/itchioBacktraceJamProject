using Game.Gameplay.Targets;
using Game.Infrastructure.Services;
using Game.UI;

namespace Game.Application.GameScore
{
  public class CurrentScore
  {
    public int Value { get; private set; }

    public void AddFor(Target target)
    {
      Value += target.ScorePoint;
      AllServices.Instance.Resolve<Mediator>().AddScore(target.ScorePoint);
    }
  }
}