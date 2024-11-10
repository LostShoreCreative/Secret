using System;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Reflection;

class Program
{
    static string[] MainMenuText = {"MINDFULLNESS ACTIVITIES", "1. Breathing", "2. Relfection", "3. Listing", "Type the number of the activity you want, to quit"};
    static ScreenData[] MenuData = new ScreenData[5];
    static Screen screen = Screen.MainMenu;
    static bool isRunning = true;
    static string[] descriptions = {"This activity will help clear your mind", "This will help you reflect on your strength", "This will help you consider the good things in life"};
    static Activity curActivity = new Activity("NULL");

    static string[][] frames = new string[][]
    {
        new string[]{
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        "  
        },
        new string[]{
            "##                    ##",
            "##                    ##",
            "                        ",
            "                        ",
            "                        ",
            "##                    ##",
            "##                    ##"  
        },
        new string[]{
            "####                ####",
            "####                ####",
            "                        ",
            "                        ",
            "                        ",
            "####                ####",
            "####                ####"  
        },
        new string[]{
            "######            ######",
            "######            ######",
            "                        ",
            "                        ",
            "                        ",
            "######            ######",
            "######            ######"  
        },
        new string[]{
            "########        ########",
            "########        ########",
            "                        ",
            "                        ",
            "                        ",
            "########        ########",
            "########        ########"  
        },
        new string[]{
            "########        ########",
            "##########    ##########",
            "        ##    ##        ",
            "                        ",
            "        ##    ##        ",
            "##########    ##########",
            "########        ########"  
        },
        new string[]{
            "########        ########",
            "##########    ##########",
            "        ########        ",
            "                        ",
            "        ########        ",
            "##########    ##########",
            "########        ########"  
        },
        new string[]{
            "########        ########",
            "##########    ##########",
            "        ########        ",
            "          ####          ",
            "        ########        ",
            "##########    ##########",
            "########        ########"  
        },
        new string[]{
            "########   ||   ########",
            "##########    ##########",
            "        ########        ",
            "=====     ####     =====",
            "        ########        ",
            "##########    ##########",
            "########   ||   ########"  
        },
        new string[]{
            "########   ||   ########",
            "########## || ##########",
            "        ########        ",
            "========= #### =========",
            "        ########        ",
            "########## || ##########",
            "########   ||   ########"
        },
    };
    static ScreenData[][] frameData;
    static int currentFrame = 0;
    static void Main(string[] args)
    {
        InitMenuData();
        InitFrames();
        while(isRunning)
        {
            switch(screen)
            {
                case Screen.MainMenu:
                WindowManager.BuildScreen(MenuData);
                HandleMainMenu();
                break;
                case Screen.Time:
                ScreenData timeData = new ScreenData("How long will the activity last".ToCharArray(), 2, WindowManager.GetWidth()/2-"How long will the activity last".Length/2);
                WindowManager.BuildScreen(new ScreenData[]{timeData});
                HandleTime();
                break;
                case Screen.Activities:
                HandleNull();
                break;
            }
        }
    }

    static void HandleMainMenu()
    {
        switch(Console.ReadLine().ToUpper())
        {
            case "1":
            screen = Screen.Time;
            curActivity = new Breathing(descriptions[0]);
            break;
            case "2":
            screen = Screen.Time;
            string[] prompt1 = {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless.",
                };
            string[] prompt2 = {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?"
            };
            curActivity = new Reflection(descriptions[1], prompt1, prompt2);
            break;
            case "3":
            screen = Screen.Time;
            curActivity = new Listing(descriptions[2]);
            break;
            case "Q":
            isRunning = false;
            break;
        }
    }
    
    static void HandleTime()
    {
        curActivity.SetTime(int.Parse(Console.ReadLine()));
        screen = Screen.Activities;
    }


    static void HandleNull()
    {
        ScreenData dataOut = curActivity.Run();
        WindowManager.BuildScreen(ConcatData(dataOut));
        if(currentFrame == 9) currentFrame = 0;
        else currentFrame++;
        Thread.Sleep(100);
    }

    static ScreenData[] ConcatData(ScreenData data)
    {
        ScreenData[] renderData = new ScreenData[frameData[0].Length + 1];
        renderData[7] = data;
        for(int row = 0; row < renderData.Length-1; row++)
        {
            renderData[row] = frameData[currentFrame][row];
        }
        return renderData;
    }

    static void InitMenuData()
    {
        for (int i = 0; i < MainMenuText.Length; i++)
        {
            string text = MainMenuText[i];
            MenuData[i] = new ScreenData(text.ToCharArray(), WindowManager.GetHeight()/2-3+i, WindowManager.GetWidth()/2-text.Length/2);
        }
    }

    static void InitFrames()
    {
        frameData = new ScreenData[frames.Length][];
        for(int frame = 0; frame < frames.Length; frame++)
        {
            frameData[frame] = new ScreenData[frames[frame].Length];
            for(int line = 0; line < frameData[frame].Length; line++)
            {
                string text = frames[frame][line];
                frameData[frame][line] = new ScreenData(text.ToCharArray(), WindowManager.GetHeight()/2+line, WindowManager.GetWidth()/2 - text.Length/2);
            }
        }
    }

    public static void Stop()
    {
        screen = Screen.MainMenu;
    }
}
