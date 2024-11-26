
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
            Program.ChangeWindow(new ListGoalsInput(), new ListGoalsWindow());
            break;
            case ConsoleKey.D3:
            GoalTracker.SaveGoals();
            break;
            case ConsoleKey.D4:
            Program.Stop();
            break;
        }
    }
}