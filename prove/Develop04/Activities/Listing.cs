class Listing : Activity
{
    int loopsPerSec =1;
    string[] prompts;
    ScreenData data;
    public Listing(string description) : base(description)
    {
        prompts = new string[]{
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
            };
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        data = new ScreenData(prompt.ToCharArray(), 3, WindowManager.GetWidth()/2 - prompt.Length/2);
    }

    public override ScreenData Run()
    {
        if(loopsPerSec%10 == 0)
        {
            base.Run();
        }
        loopsPerSec++;
        return data;
    }
}