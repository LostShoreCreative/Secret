using System;
using System.Collections;
using System.ComponentModel.Design;

class Program
{
    static bool isRunning = true;
    static Screen screen = Screen.MainMenu;
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

    public void SwitchScreen(Screen newScreen){}

    public static void Stop()
    {
        isRunning = false;
    }
}