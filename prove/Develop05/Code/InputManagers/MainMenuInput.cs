
class MainMenuInput : InputManager
{
    public override void HandleInput(ConsoleKeyInfo cki)
    {
        switch(cki.Key)
        {
            case ConsoleKey.D1:
            Program.ChangeWindow(new NewGoalInput(), new NewGoalWindow());
            break;
            case ConsoleKey.D2:
            break;
            case ConsoleKey.D3:
            break;
            case ConsoleKey.D4:
            break;
            case ConsoleKey.D5:
            break;
            case ConsoleKey.D6:
            Program.Stop();
            break;
        }
    }
}