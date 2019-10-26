using System;

class SaveFiles
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
        THREEDS,
    }

    public int ID { get; set; }
    public string Game { get; set; }
    public string OriginalPath { get; set; }
    public string BackupPath { get; set; }
    internal Platforms Platform { get; set; }
    public DateTime LastBackupDate { get; set; }

    public SaveFiles(int _ID, string _Game, string _OriginalPath, Platforms _Platform)
    {
        ID = _ID;
        Game = _Game;
        OriginalPath = _OriginalPath;
        Platform = _Platform;
    }
}