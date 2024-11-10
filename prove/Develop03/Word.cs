using System.Text;

struct Word
{
  public bool isShown = true;
  private readonly string text;
  private readonly string altText;
  private const string SPECIAL_CHARS = ";:\'\",.?!";

  public Word(string text)
  {
    StringBuilder builder = new StringBuilder();
    this.text = text;
    builder.Append('_', text.Length-1);
    foreach(char unique in SPECIAL_CHARS)
    {
      if(text.Contains(unique))
      {
        builder.Append(unique);
        altText = builder.ToString();
        return;
      }
    }
    builder.Append('_');
    altText = builder.ToString();
  }

    public override string ToString()
    {
        return (isShown)?text:altText;
    }
}