using Game.Application.Data;
using Game.Gameplay.Targets;
using Game.Infrastructure.Services;
using Game.UI;

namespace Game.Application.GameScore
{
  public class Score
  {
    public static Score Instance = new Score();
    
    private readonly HighestScore _newRecordChecker = new HighestScore();

    public bool IsNewRecord => _newRecordChecker.RecordUpdated;

    private int _current;
    
    public int Current
    {
      get => _current;
      private set => _current = value < 0 ? 0 : value;
    }

    public int Highest => _newRecordChecker.RecordScore;
    
    public static void Reset()
    {
      Instance.Current = 0;
      Instance._newRecordChecker.Reset();
      AllServices.Instance.Resolve<Mediator>().ResetScore();
    }

    public void AddFor(Target target)
    {
      Current += target.ScorePoint;
      _newRecordChecker.CheckRecord(Current);
      AllServices.Instance.Resolve<Mediator>().AddScore(target.ScorePoint);
    }

    public void Decrease(int value)
    {
      Current -= value;
      _newRecordChecker.CheckRecord(Current);
      AllServices.Instance.Resolve<Mediator>().AddScore(-value);
      
    }
  }
}