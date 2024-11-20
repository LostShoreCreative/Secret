using System.Text;

static class WindowManager
{
  static int height = Console.WindowHeight-1;
  static int width = Console.WindowWidth;

  static char[][] window = new char[height][];
  static StringBuilder rowBuilder = new StringBuilder(width);

  private static void Render()
  {
    Console.Clear();
    foreach(char[] row in window)
    {
      rowBuilder.Clear();
      foreach(char pixel in row)
      {
        if(pixel == 0) rowBuilder.Append(" ");
        else rowBuilder.Append(pixel);
      }
      Console.WriteLine(rowBuilder);
    }
  }

  static WindowManager()
  {
    SetScreenSize();
    BuildBorder();
  }

  private static void BuildBorder()
  {
    int arrayHeight = height-1;
    int arrayWidth = width-1;
    FillRow('_', 0, 1, arrayWidth);
    FillColumn('|', 0, 1, height);
    FillColumn('|', arrayWidth, 1, height);
    FillRow('_', arrayHeight, 1, arrayWidth);
  }

  public static void BuildScreen(ScreenData[] dataList)
  {
    ClearWindow();
    foreach(ScreenData screenData in dataList)
    {
      for(int index = 0; index < screenData.data.Length; index++)
      {
        window[screenData.row][screenData.column + index] = screenData.data[index];
      }
    }
    Render();
  }

  public static void BuildScreen(ScreenData data)
  {
    ClearWindow();
    for(int i = 0; i < data.data.Length; i++)
    {
      window[data.row][data.column+i] = data.data[i];
    }
    Render();
  }

  private static void FillRow(char value, int row, int start, int end)
  {
    for(;start < end; start++)
    {
      window[row][start] = value;
    }
  }

  private static void FillColumn(char value, int column, int start, int end)
  {
    for(;start < end; start++)
    {
      window[start][column] = value;
    }
  }

  private static void ClearWindow()
  {
    for(int row = 1; row < height-1; row++)
    {
      FillRow(new char(), row, 1, width-1);
    }
  }

  private static void SetScreenSize()
  {
    window = new char[height][];
    for(int index = 0; index < window.Length; index++)
    {
      window[index] = new char[width];
    }
  }

  public static int GetHeight()
  {
    return height;
  }

  public static int GetWidth()
  {
    return width;
  }

  public static int CenterTextOnColumn(string text)
  {
    return width/2-text.Length/2;
  }
}