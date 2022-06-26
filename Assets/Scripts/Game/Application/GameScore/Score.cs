using Game.Gameplay.Targets;
using Game.Infrastructure.Services;
using Game.UI;

namespace Game.Application.GameScore
{
  public class Score
  {
    public static Score Instance;
    
    public int Value { get; private set; }

    public static void Reset()
    {
      Instance = new Score();
      AllServices.Instance.Resolve<Mediator>().ResetScore();
    }

    public void AddFor(Target target)
    {
      Value += target.ScorePoint;
      AllServices.Instance.Resolve<Mediator>().AddScore(target.ScorePoint);
    }
  }
}