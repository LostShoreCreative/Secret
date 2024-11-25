static class GoalTracker
{
  static List<Goal> goals;
  static int points;

  static GoalTracker()
  {
    goals  = new List<Goal>();
    points = 0;
  }

  public static void MakeSimpleGoal(string name, string description, int points)
  {
    goals.Add(new SimpleGoal(name, description, points));
  }

  public static void MakeEternalGoal(string name, string description, int points)
  {
    goals.Add(new EternalGoal(name, description, points));
  }

  public static void SaveGoals()
  {

  }

  public static void AddPoints(int value)
  {
    points += value;
  }
}