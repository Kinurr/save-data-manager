using System;

public class SaveFile
{
    public enum Platforms
    {
        PC,
        PS1,
        PS2,
        PS3,
        PS4,
        PSP,
        PSVITA,
        XBOX,
        XBOX360,
        XBOXONE,
        NES,
        SNES,
        N64,
        GAMECUBE,
        WII,
        WIIU,
        SWITCH,
        GAMEBOY,
        GAMEBOYCOLOR,
        GAMEBOYADVANCE,
        DS,
        THREE_DS,
    }

    public int ID { get; set; }
    public string Title { get; set; }
    public string OriginalPath { get; set; }
    internal Platforms Platform { get; set; }
    public DateTime LastBackupDate { get; set; }

    public SaveFile(int _ID, string _Game, string _OriginalPath, Platforms _Platform)
    {
        ID = _ID;
        Title = _Game;
        OriginalPath = _OriginalPath;
        Platform = _Platform;
    }
}