using System.Data;
using System.Net.Http.Headers;

class Activity
{
    int time;
    string description;

    public Activity(string description)
    {
        this.description = description;
    }

    public void SetTime(int time)
    {
        this.time = time;
    }

    public virtual ScreenData Run()
    {
        if(time == 0)
        {
            Program.Stop();
        }
        time--;
        return new ScreenData(new char[]{'N','U','L','L'}, 3, 1);
    }
}