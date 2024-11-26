using System.Text.Json;

static class GoalTracker
{
  static List<Goal> goals;
  static int points;

  static GoalTracker()
  {
    try
    {
      goals = new List<Goal>();
      string sJson = File.ReadAllText("simpleGoalJson.txt");
      string eJson = File.ReadAllText("eternalGoalJson.txt");
      string cJson = File.ReadAllText("checklistGoalJson.txt");
      List<SimpleGoal> sGoals = JsonSerializer.Deserialize<List<SimpleGoal>>(sJson);
      List<EternalGoal> eGoals = JsonSerializer.Deserialize<List<EternalGoal>>(eJson);
      List<CheckListGoal> simpleGoals = JsonSerializer.Deserialize<List<CheckListGoal>>(cJson);
    }
    catch
    {
      goals = new List<Goal>();
    }
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
    List<SimpleGoal> simpleGoals = new List<SimpleGoal>();
    List<EternalGoal> eternalGoals = new List<EternalGoal>();
    List<CheckListGoal> checkListGoals = new List<CheckListGoal>();
    Type simpleGoalType = typeof(SimpleGoal);
    Type eternalGoalType = typeof(EternalGoal);
    foreach(Goal goal in goals)
    {
      Type goalType = goal.GetType();
      if(goalType == simpleGoalType) simpleGoals.Add((SimpleGoal)goal);
      else if(goalType == eternalGoalType) eternalGoals.Add((EternalGoal)goal);
      else checkListGoals.Add((CheckListGoal)goal);
    }
    SaveList<SimpleGoal>(simpleGoals, "simpleGoalJson.txt");
    SaveList<EternalGoal>(eternalGoals, "eternalGoalJson.txt");
    SaveList<CheckListGoal>(checkListGoals, "checklistGoalJson.txt");
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
}