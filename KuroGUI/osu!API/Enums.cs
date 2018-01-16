namespace KuroGUI.osuAPI
{
    public enum GameMode
    {
        Standard = 0,
        Taiko = 1,
        Catch = 2,
        Mania = 3
    }
    public enum Mods
    {
        NM = 0,
        NF= 1,
        EZ = 2,
        NoVideo = 4,
        HD = 8,
        HR = 16,
        SD = 32,
        DT = 64,
        RX = 128,
        HT = 256,
        NC = 512,
        FL = 1024,
        Auto = 2048,
        SO = 4096,
        AP = 8192,
        PF = 16384,
        Key4 = 32768,
        Key5 = 65536,
        Key6 = 131072,
        Key7 = 262144,
        Key8 = 524288,
        keyMod = Key4 | Key5 | Key6 | Key7 | Key8,
        FadeIn = 1048576,
        Random = 2097152,
        LastMod = 4194304,
        FreeModAllowed = NF | EZ | HD | HR | SD | FL | FadeIn | RX | AP | SO | keyMod,
        Key9 = 16777216,
        Key10 = 33554432,
        Key1 = 67108864,
        Key3 = 134217728,
        Key2 = 268435456
    }
}
