class Entry
{
  public DateTime date{get; private set;}
  public string text{get; private set;}

  public Entry(string text)
  {
    this.text = text;
    date = DateTime.Today;
  }

  public string GetEntry()
  {
    return $"{date}\n{text}";
  }

  public string GetDate()
  {
    return date.ToString();
  }
}