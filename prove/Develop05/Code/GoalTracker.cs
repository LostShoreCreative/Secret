using System.Text.Json;
using System.Text.Json.Serialization;

static class GoalTracker
{
  static List<Goal> goals;
  static int points;

  static GoalTracker()
  {
    goals = new List<Goal>();
    points = 0;
  }

  static void ParseLists(List<Goal> list)
  {
    foreach(Goal goal in list)
    {
      goals.Add(goal);
    }
  }
  public static void MakeSimpleGoal(string name, string description, int points)
  {
    goals.Add(new SimpleGoal(name, description, points));
  }

  public static void MakeEternalGoal(string name, string description, int points)
  {
    goals.Add(new EternalGoal(name, description, points));
  }

  public static void MakeCheckListGoal(string name, string description, int points, int timesToLoop, int bonusPoints)
  {
    goals.Add(new CheckListGoal(name, description, points, timesToLoop, bonusPoints));
  }

  public static void SaveGoals()
  {
  }

  static void SaveList<T>(List<T> data, string path)
  {
    string jsonString = JsonSerializer.Serialize(data);
    File.WriteAllText(path, jsonString);
  }

  public static void AddPoints(int value)
  {
    points += value;
  }

  public static Goal[] GetGoals()
  {
    return goals.ToArray();
  }

  public static void MarkGoalDone(int index)
  {
    goals[index].GoalDone();
  }

  public static int GetPoints()
  {
    return points;
  }
}