static class GoalTracker
{
  static List<Goal> goals;
  static int points;

  static GoalTracker()
  {
    goals  = new List<Goal>();
    points = 0;
  }
}