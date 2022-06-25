using Game.Gameplay.Targets;

namespace Game.Application.GameScore
{
  public class CurrentScore
  {
    public int Value { get; private set; }

    public void AddFor(Target target)
    {
      Value += target.ScorePoint;
    }
  }
}