using System;
public class EggCollected
{

    public static event Action on;

    public static void trigger()
    {
        on?.Invoke();
    }
}