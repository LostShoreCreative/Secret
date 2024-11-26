using System;
using System.Collections;
using System.ComponentModel.Design;

class Program
{
    static bool isRunning = true;
    static Window window = new MainMenuWindow();
    static InputManager inputManager = new MainMenuInput();

    static void Main(string[] args)
    {
        Thread inputThread = new Thread(new ThreadStart(ReadFromConsole));
        inputThread.Start();
        while(isRunning)
        {
            WindowManager.BuildScreen(window.GetScreenData());
            Thread.Sleep(33);
        }
    }

    static void ReadFromConsole()
    {
        while(isRunning)
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            inputManager.HandleInput(cki);
            Thread.Sleep(10);
        }
    }

    public static void Stop()
    {
        isRunning = false;
    }

    public static void ChangeWindow(InputManager newInputManager, Window newWindow)
    {
        inputManager = newInputManager;
        window = newWindow;
    }
}