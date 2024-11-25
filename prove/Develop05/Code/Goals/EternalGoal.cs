class EternalGoal : Goal
{
  int timesCompleted;
  public EternalGoal(string name, string description, int points) : base(name, description, points)
  {
    timesCompleted = 0;
  }

    public override void GoalDone()
    {
      base.GoalDone();
      timesCompleted++;
    }

    public override string ToString()
    {
        return $"[{timesCompleted}] {base.ToString()}";
    }
}