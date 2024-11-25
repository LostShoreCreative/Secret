class SimpleGoal : Goal, ICompleteable
{
  bool goalDone = false;
  public SimpleGoal(string name, string description, int points):base(name, description, points)
  {

  }

    public override void GoalDone()
    {
        base.GoalDone();
        GoalCompleted();
    }

    public void GoalCompleted()
    {
      goalDone = true;
    }

    public override string ToString()
    {
        return $"[{(goalDone?"X":" ")}] {base.ToString()}";
    }
}