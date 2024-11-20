class NewGoalWindow : Window
{
  enum GoalType
  {
    Normal,
    Eternal,
    CheckList
  }

  enum BuildTaskState
  {
    ChooseType,
    ChooseName,
    SetDescription,
    SetPointAmoumt
  }

  string[][] data = 
  {
    new string[]{"What type of goal would you like to make"},
    new string[]{},
    new string[]{},
    new string[]{}
  };
  ScreenData[] screenData;
  BuildTaskState bts = BuildTaskState.ChooseType;
  GoalType goalType;

  public override ScreenData[] GetScreenData()
  {
    return screenData;
  }

  public void IterateBTS()
  {
    bts++;
  }
}