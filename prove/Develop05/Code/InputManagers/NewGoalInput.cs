class NewGoalInput : InputManager
{
  enum GoalType
  {
    Simple,
    Eternal,
    CheckList
  }

  static readonly string[] TASK_TYPE_QUESTION = {"The types of Goals are: ", "  -Simple Goal", "  -Eternal Goal", "  -CheckList Goal", "Which type of Goal would you like: "};
  static readonly string[] QUESTIONS = 
  {
    "What is the name of your Goal: ",
    "What is a short description of it: ",
    "What is the amount of points associated with this goal: ",
    "How many times would you like this goal to be done: ",
    "How many bonus points for finishing: "
  };

  static string input = "";
  static GoalType goalType;
  static List<string> data;

  static BuildTaskState bts;

  static string goalName;
  static string goalDescription;
  static int points;
  static int bonusPoints;
  static int timesToRepeat;

  public NewGoalInput()
  {
    data = new List<string>();
    bts = BuildTaskState.ChooseType;
    input = "";
    foreach(string line in TASK_TYPE_QUESTION)
    {
      data.Add(line);
    }
    goalName = "";
    goalDescription = "";
    points = 0;
    bonusPoints = 0;
    timesToRepeat = 0;
  }

  public override void HandleInput(ConsoleKeyInfo cki)
  {
    switch(cki.Key)
    {
      case ConsoleKey.None:
      break;
      case ConsoleKey.Enter:
      HandleEnter();
      break;
      case ConsoleKey.Backspace:
      if(input.Length >= 1)
      {
        input = input.Remove(input.Length-1);
        TrasmitData();
      }
      break;
      default:
      input += cki.KeyChar;
      TrasmitData();
      break;
    }
  }
  
  public void AppendData()
  {
    data[data.Count-1] += input;
    input = "";
    data.Add(QUESTIONS[(int)bts-1]);
    TrasmitData();
  }

  public static string[] GetData()
  {
    return data.ToArray();
  }

  static void TrasmitData()
  {
    string[] tmp = data.ToArray();
    tmp[tmp.Length-1] += input;
    NewGoalWindow.RecieveData(tmp);
  }

  private void HandleEnter()
  {
    bool didExectute = false;
    switch(bts)
    {
      case BuildTaskState.ChooseType:
      didExectute = HandleChooseType();
      break;
      case BuildTaskState.ChooseName:
      didExectute = HandleChooseName();
      break;
      case BuildTaskState.SetDescription:
      didExectute = HandleSetDescription();
      break;
      case BuildTaskState.SetPointAmoumt:
      didExectute = HandleSetPointAmount();
      break;
      case BuildTaskState.SetRepition:
      didExectute = HandleSetRepition();
      break;
      case BuildTaskState.SetCompletePoints:
      didExectute = HandleSetBonusPoints();
      break;
    }
    if(didExectute) AppendData();
  }

  private bool HandleChooseType()
  {
    bts = BuildTaskState.ChooseName;
    switch(input)
    {
      case "1":
      goalType = GoalType.Simple;
      return true;
      case "2":
      goalType = GoalType.Eternal;
      return true;
      case "3":
      goalType = GoalType.CheckList;
      return true;
      default:
      bts = BuildTaskState.ChooseType;
      return false; 
    }
  }

  private bool HandleChooseName()
  {
    if(input.Trim().Equals("")) return false;
    bts = BuildTaskState.SetDescription;
    goalName = input;
    return true;
  }

  private bool HandleSetDescription()
  {
    if(input.Trim().Equals("")) return false;
    bts = BuildTaskState.SetPointAmoumt;
    goalDescription = input;
    return true;
  }

  private bool HandleSetPointAmount()
  {
    if(input.Trim().Equals("")) return false;
    points = int.Parse(input);
    if(goalType == GoalType.CheckList)
    {
      bts = BuildTaskState.SetRepition;
      return true;
    }
    switch(goalType)
    {
      case GoalType.Simple:
      GoalTracker.MakeSimpleGoal(goalName, goalDescription, points);
      break;
      case GoalType.Eternal:
      GoalTracker.MakeEternalGoal(goalName, goalDescription, points);
      break;
    }
    Program.ChangeWindow(new MainMenuInput(), new MainMenuWindow());
    return true;
  }

  private bool HandleSetRepition()
  {
    if(input.Trim().Equals("")) return false;
    bts = BuildTaskState.SetCompletePoints;
    timesToRepeat = int.Parse(input);
    return true;
  }

  private bool HandleSetBonusPoints()
  {
    if(input.Trim().Equals("")) return false;
    bonusPoints = int.Parse(input);
    GoalTracker.MakeCheckListGoal(goalName, goalDescription, points, timesToRepeat, bonusPoints);

    Program.ChangeWindow(new MainMenuInput(), new MainMenuWindow());
    return true;
  }
}