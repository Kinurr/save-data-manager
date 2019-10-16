struct SaveFiles
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

    public string ID, Game, OriginalPath, BackupPath;
    public Platforms Platform;
    public System.DateTime lastBackupDate;
}