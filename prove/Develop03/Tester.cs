using System.Text.Json;
using System.Text.Json.Serialization;

static class Tester
{
  private static List<Scripture> scriptures = new List<Scripture>();
  Scripture scripture;

  static Tester()
  {
    try
    {
      string jsonString = File.ReadAllText("save.txt");
      scriptures = JsonSerializer.Deserialize<List<Scripture>>(jsonString);
    }
    catch
    {
      scriptures = new List<Scripture>();
    }
  }

  public static void MakeScripture(string reference, string text)
  {
    scriptures.Add(new Scripture(reference, text));
    Save();
  }

  static void Save()
  {
    string jsonString = JsonSerializer.Serialize(scriptures);
    File.WriteAllText("save.txt", jsonString);
  }

  public void SelectScripture(int index)
  {
    scripture = scriptures[index];
  }

  public void GetScriptures()
  {
    return scriptures;
  }

  public string GetScripture()
  {
    return scripture.ToString();
  }

  public void RemoveWord()
  {
    Random rand = new Random();
    int ranIndex;
    Word[] words = scripture.GetWords();
    do
    {
      ranIndex = rand.Next(words.Length);
    }while(!words[ranIndex].isShown)
    words[i].isShown = false;
  }
}