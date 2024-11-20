class NewGoalWindow : Window
{

  public NewGoalWindow()
  {
    bts = BuildTaskState.ChooseType;
    screenData = new List<ScreenData>();
    MakeScreenData();
  }
  enum GoalType
  {
    Normal,
    Eternal,
    CheckList
  }

  static string[][] data = 
  {
    new string[]{"What type of goal would you like to make", "1. Simple Goal", "2. Eternal Goal", "3. Checklist Goal", "Choose the number of the Goal you'd like: "},
    new string[]{"What is the name of your goal: "},
    new string[]{"Write a brief description of your goal: "},
    new string[]{"What is the amount of points associated with your goal: "}
  };
  static List<ScreenData> screenData;
  static ScreenData[] inputData = new ScreenData[4];
  static BuildTaskState bts = BuildTaskState.ChooseType;
  static GoalType goalType;
  static int inputDataRow;

  public override ScreenData[] GetScreenData()
  {
    return screenData.ToArray();
  }

  public static void IterateBTS()
  {
    bts++;
    MakeScreenData();
  }

  public static BuildTaskState GetBTS()
  {
    return bts;
  }

  private static void MakeScreenData()
  {
    string[] toConvert = data[(int)bts];
    for(int i = 0; i < toConvert.Length; i++)
    {
      char[] current = toConvert[i].ToCharArray();
      if(i == 0)
      {
        inputDataRow = 2+screenData.Count;
        screenData.Add(new ScreenData(current, inputDataRow, 1));
      }
      else if(i == toConvert.Length-1) screenData.Add(new ScreenData(current, 2+i+screenData.Count, 1));
      else screenData.Add(new ScreenData(current, 2+i+screenData.Count, 3));
    }
  }

  public static void RecieveInputInfo(string inputInfo, int chosenType)
  {
    goalType = (GoalType)chosenType-1;
    inputData[(int)goalType] = new ScreenData(inputInfo.ToCharArray(), inputDataRow, screenData[inputDataRow].data.Length);
  }
}