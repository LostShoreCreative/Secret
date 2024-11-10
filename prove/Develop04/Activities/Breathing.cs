class Breathing : Activity
{
    int loopsPerSec;
    string[] displayText = {"Breath In...", "Breath Out..."};
    ScreenData[] displayData = new ScreenData[2];
    bool breathingOut = false;
    public Breathing(string description) : base(description)
    {
        loopsPerSec = 0;
        for(int i = 0; i < displayData.Length; i++)
        {
            displayData[i] = new ScreenData(displayText[i].ToCharArray(), 3, WindowManager.GetWidth()/2 - displayText[i].Length/2);
        }
    }

    public override ScreenData Run()
    {
        if(loopsPerSec%10 == 0)
        {
            base.Run();
        }
        if(loopsPerSec%30 == 0)
        {
            breathingOut = !breathingOut;
        }
        loopsPerSec++;
        return displayData[breathingOut.GetHashCode()];
    }
}