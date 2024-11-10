class Reflection : Activity
{
    string[] prompt1;
    string[] prompt2;
    int loopsPerSec = 0;

    string chosen1;
    string chosen2;
    ScreenData[] chosenData = new ScreenData[2];
    bool onPrompt1 = true;
    public Reflection(string description, string[] promp1, string[] prompt2) : base(description)
    {
        this.prompt1 = promp1;
        this.prompt2 = prompt2;
        SetPrompts();
    }

    public override ScreenData Run()
    {
        if(loopsPerSec%10 == 0)
        {
            base.Run();
        }
        if(loopsPerSec%50 == 0 && onPrompt1 && loopsPerSec != 0)
        {
            onPrompt1 = false;
        }
        else if(loopsPerSec%50 == 0 && !onPrompt1)
        {
            onPrompt1 = true;
            SetPrompts();
        }
        loopsPerSec++;
        return (onPrompt1)?chosenData[0]:chosenData[1];
    }

    private void SetPrompts()
    {
        Random rand = new Random();
        chosen1 = prompt1[rand.Next(prompt1.Length)];
        chosen2 = prompt2[rand.Next(prompt2.Length)];
        chosenData[0] = new ScreenData(chosen1.ToCharArray(), 2, WindowManager.GetWidth()/2-chosen1.Length/2);
        chosenData[1] = new ScreenData(chosen2.ToCharArray(), 2, WindowManager.GetWidth()/2-chosen2.Length/2);
    }
}