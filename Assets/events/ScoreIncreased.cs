using System;
public class ScoreIncreased
{

    public static event Action on;

    public static void trigger()
    {
        on?.Invoke();
    }
}