class MainMenuWindow : Window
{
  string[] data = {"MENU OPTIONS", "1. Create New Goal", "2. List Goals", "3. Save Goals", "4. Quit", "Type the number of the goal you want", $"Points: {GoalTracker.GetPoints()}"};
  ScreenData[] formattedData;

  public MainMenuWindow()
  {
    formattedData = new ScreenData[data.Length];
    int middleRow = WindowManager.GetHeight()/2-4;
    for(int i = 0; i < data.Length; i++)
    {
      string text = data[i];
      if(i == 0 || i == data.Length-1 || i == data.Length-2)
      {
        formattedData[i] = new ScreenData(text.ToCharArray(), middleRow+i, WindowManager.CenterTextOnColumn(data[0]));
      }
      else
      {
        formattedData[i] = new ScreenData(text.ToCharArray(), middleRow+i, WindowManager.GetWidth()/2-4);
      }
    }
  }

  public override ScreenData[] GetScreenData()
  {
    return formattedData;
  }
}