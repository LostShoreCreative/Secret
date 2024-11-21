class NewGoalWindow : Window
{
  static ScreenData[] data;

  public NewGoalWindow()
  {
    string[] tmp = NewGoalInput.GetData();
    data = new ScreenData[tmp.Length];
    for(int i = 0; i < tmp.Length; i++)
    {
      string line = tmp[i];
      data[i] = new ScreenData(line.ToCharArray(), i+1, 1);
    }

  }

  public override ScreenData[] GetScreenData()
  {
    return data.ToArray();    
  }

  public static void RecieveData(string[] dataToAdd)
  {
    data = new ScreenData[dataToAdd.Length];
    for(int index = 0; index < dataToAdd.Length; index++)
    {
      string line = dataToAdd[index];
      data[index] = new ScreenData(line.ToCharArray(), 1+index, 1);
    }
  }
}