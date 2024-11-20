
using System.Reflection;

class NewGoalInput : InputManager
{
  string inputInfo = "";
  public override void HandleInput(ConsoleKeyInfo cki)
  {
    
    BuildTaskState bts = NewGoalWindow.GetBTS();
    switch(bts)
        {
          case BuildTaskState.ChooseType:
          HandleChooseType(cki);
          break;
          case BuildTaskState.ChooseName:
          break;
          case BuildTaskState.SetDescription:
          break;
          case BuildTaskState.SetPointAmoumt:
          break;
        }
    }

    private void HandleChooseType(ConsoleKeyInfo cki)
    {
      switch(cki.Key)
      {
        case ConsoleKey.Enter:
        NewGoalWindow.IterateBTS();
        break;
        case ConsoleKey.Backspace:
        inputInfo = inputInfo.Substring(0, inputInfo.Length-2);
        break;
        case ConsoleKey.None:
        break;
        default:
        inputInfo += cki.KeyChar;
        break;

      }
    }
}