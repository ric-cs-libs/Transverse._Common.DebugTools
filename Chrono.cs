using System.Diagnostics;

namespace Transverse._Common.DebugTools;

public class Chrono
{
    private readonly Stopwatch chrono;

    public Chrono()
    {
        chrono = new Stopwatch();
    }

    public void Start()
    {
        chrono.Start();
    }

    public Chrono Stop()
    {
        chrono.Stop();

        return this;
    }

    public long GetElapsedTime()
    {
        return chrono.ElapsedMilliseconds;
    }

    public void Show(string format = "\n - Temps écoulé : {0}ms -")
    {
        Console.WriteLine(string.Format(format, GetElapsedTime()));
    }

    public void StopAndShowDuration()
    {
        this.Stop().Show();
    }

}
