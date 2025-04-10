using System;
public class UI
{

    public static event Action onEggsCollectedChanged;

    public static void updateCollectedEggs()
    {
        onEggsCollectedChanged?.Invoke();
    }
}