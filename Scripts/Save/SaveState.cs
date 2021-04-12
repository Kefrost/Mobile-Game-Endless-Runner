using System;

[System.Serializable]
public class SaveState
{
    [NonSerialized] private const int hatCount = 16;

    public int Highscore { get; set; }
    public int Scrap { get; set; }
    public DateTime LastSaveTime { get; set; }
    public int CurrentHatIndex { get; set; }
    public byte[] UnlockedHatFlag { get; set; }


    public SaveState()
    {
        Highscore = 0;
        Scrap = 0;
        LastSaveTime = DateTime.Now;
        CurrentHatIndex = 0;
        UnlockedHatFlag = new byte[hatCount];
        UnlockedHatFlag[0] = 1;
    }
}
