using System.Text.Json.Serialization;

class Scripture
{
  [JsonInclude]
  public readonly string reference;
  [JsonInclude]
  private string text;
  [JsonInclude]
  private Word[] words;

  public Scripture(string reference, string text)
  {
    this.reference = reference;
    this.text = text;
    string[] textList = text.Split(' ');
    words = new Word[textList.Length];
    for(int i = 0; i < textList.Length; i++)
    {
      words[i] = new Word(textList[i]);
    }
  }

  public Word[] GetWords()
  {
    return words;
  }

  public override string ToString()
  {
    string returnString = "";
    foreach(Word word in words)
    {
      returnString += $"{word} ";
    }
    return returnString;
  }
}