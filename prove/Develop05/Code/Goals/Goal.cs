using System.Text.Json.Serialization;

abstract class Goal
{
  [JsonInclude]
  string name;
  [JsonInclude]
  string description;
  [JsonInclude]
  int points;

  public Goal(string name, string description, int points)
  {
    this.name = name;
    this.description = description;
    this.points = points;
  }

  public int GetPoints()
  {
    return points;
  }

  public virtual void GoalDone()
  {
    GoalTracker.AddPoints(points);
  }

  public override string ToString()
  {
    return $"{name} ({description})";
  }
}