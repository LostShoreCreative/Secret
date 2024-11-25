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
    "What is the amount of points associated with this goal: "
  };

  static string input = "";
  static GoalType goalType;
  static List<string> data;

  static BuildTaskState bts;

  static string goalName;
  static string goalDescription;
  static int points;

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
      break;
    }
    return true;
  }
}