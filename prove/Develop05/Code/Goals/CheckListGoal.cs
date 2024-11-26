using System.Text.Json.Serialization;

class CheckListGoal : Goal, ICompleteable
{
  [JsonInclude]
  readonly int TIMES_TO_COMPLETE;
  [JsonInclude]
  int bonusPoints;
  [JsonInclude]
  int timesCompleted;
  [JsonInclude]
  bool goalCompleted;
  public CheckListGoal(string name, string description, int points, int completeTimes, int bonus) : base(name, description, points)
  {
    TIMES_TO_COMPLETE = completeTimes;
    bonusPoints = bonus;
    timesCompleted = 0;
    goalCompleted = false;
  }

  public override void GoalDone()
  {
    timesCompleted++;
    if(timesCompleted == TIMES_TO_COMPLETE)
    {
      GoalCompleted();
      base.GoalDone();
    }
    else if(timesCompleted < TIMES_TO_COMPLETE) base.GoalDone();
  }

  public void GoalCompleted()
  {
    GoalTracker.AddPoints(bonusPoints);
    goalCompleted = true;
  }

  public override string ToString()
  {
    string tmp = goalCompleted?"X":$"{timesCompleted}/{TIMES_TO_COMPLETE}";
    return $"[{tmp}] {base.ToString()}";
  }
}