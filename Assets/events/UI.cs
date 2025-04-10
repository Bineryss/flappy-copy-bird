using System;
public class UI
{

    public delegate void OnEggsCollectedChanged(int newEggCount);
    public static event OnEggsCollectedChanged EggsCollectedChanged;

    public static void updateCollectedEggs(int count)
    {
        EggsCollectedChanged?.Invoke(count);
    }
}