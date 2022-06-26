namespace Game.Application.Data
{
  public class HighestScore
  {
    public bool RecordUpdated { get; private set; }
    public int RecordScore { get; private set; }

    public HighestScore() =>
      Reset();

    public void Reset() => 
      RecordUpdated = false;

    public void CheckRecord(int score)
    {
      if (score > RecordScore)
      {
        RecordUpdated = true;
        RecordScore = score;
      }
    }
  }
}