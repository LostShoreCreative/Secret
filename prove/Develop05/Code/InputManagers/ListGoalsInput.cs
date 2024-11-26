
using System.Reflection.Metadata;

class ListGoalsInput : InputManager
{
  static Goal[] goals;
  static string[] data;
  static int page;
  static int MAX_PAGE;
  static int selectedTask;
  const string DIRECTIONS = "Use the arrow keys to navigate. Press enter to complete a task. Q to quit";

  public ListGoalsInput()
  {
    selectedTask = 0;
    page = 0;
    goals = GoalTracker.GetGoals();
    MAX_PAGE = (int)(goals.Length/5.0 + 0.8);
    MakeData();
  }
  public override void HandleInput(ConsoleKeyInfo cki)
  {

    switch(cki.Key)
    {
      case ConsoleKey.Enter:
      HandleEnter();
      break;
      case ConsoleKey.LeftArrow:
      HandleLeftArrow();
      break;
      case ConsoleKey.RightArrow:
      HandleRightArrow();
      break;
      case ConsoleKey.DownArrow:
      HandleDownArrow();
      break;
      case ConsoleKey.UpArrow:
      HandleUpArrow();
      break;
      case ConsoleKey.Q:
      HandleQ();
      break;
    }
    TransmitData();
  }

  public static string[] GetData()
  {
    string[] trasmitData = data;
    string selectedTaskString = "->";
    trasmitData[selectedTask+1] = selectedTaskString + trasmitData[selectedTask+1];
    return trasmitData;
  }

  private string[] MakePageData()
  {
    int pageLength = 5;
    if(page*5 < goals.Length) pageLength = goals.Length%5;
    string[] pageData = new string[pageLength];
    for(int i = 0; i < pageLength; i++)
    {
      int goalsIndex = i + page * 5;
      pageData[i] = goals[goalsIndex].ToString();
    }
    return pageData;
  }

  private string FormatCurrentPage()
  {
    return $"Page: {page+1}/{MAX_PAGE}";
  }

  private void MakeData()
  {
    string[] pageData = MakePageData();
    string currentPageDirectory = FormatCurrentPage();
    data = new string[pageData.Length + 2];
    for(int i = 0; i < data.Length; i++)
    {
      if(i == 0) data[i] = DIRECTIONS;
      else if(i == data.Length-1) data[i] = currentPageDirectory;
      else data[i] = pageData[i-1]; 
    }
  }

  private void HandleEnter()
  {
    GoalTracker.MarkGoalDone(selectedTask + (page * 5));
  }

  private void HandleUpArrow()
  {
    if(selectedTask == 0) selectedTask = 4;
    else selectedTask++;
  }

  private void HandleDownArrow()
  {
    if(selectedTask == 4) selectedTask = 0;
    else selectedTask--;
  }

  private void HandleLeftArrow()
  {
    if(page == 0 ) page = MAX_PAGE;
    else page--;
  }

  private void HandleRightArrow()
  {
    if(page == MAX_PAGE) page = 0;
    else page++;
  }

  private void HandleQ()
  {
    Program.ChangeWindow(new MainMenuInput(), new MainMenuWindow());
  }

  public void TransmitData()
  {
    ListGoalsWindow.RecieveData(GetData());
  }
}