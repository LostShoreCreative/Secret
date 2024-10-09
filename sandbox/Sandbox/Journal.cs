using System;
using System.Text.Json;
using System.Xml.Linq;

static class Journal
{
  static string filename = "save.json";
  static List<Entry> journalEntries;
  static Journal()
  {
    try
    {
      string jsonString = File.ReadAllText(filename);
      journalEntries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
    }
    catch
    {
      journalEntries = new List<Entry>();
    }
  }

  public static void Save()
  {
    var options = new JsonSerializerOptions { WriteIndented = true };
    string jsonString = JsonSerializer.Serialize<List<Entry>>(journalEntries, options);
    File.WriteAllText(filename, jsonString);
  }

  public static void MakeEntry(string text)
  {
    journalEntries.Add(new Entry(text));
  }

  public static List<Entry> GetEntries()
  {
    return journalEntries;
  }

  public static string GetEntry(int index)
  {
    return journalEntries[index].GetEntry();
  }

}