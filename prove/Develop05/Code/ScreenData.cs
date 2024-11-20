struct ScreenData
{
  public readonly int row;
  public readonly int column;
  public readonly char[] data;

  public ScreenData(char[] data, int row, int column)
  {
    this.data = data;
    this.row = row;
    this.column = column;
  }
}