using System;
public class GameOver
{
    public static event Action on;

    public static void trigger()
    {
        on?.Invoke();
    }
}