using System.ComponentModel.DataAnnotations;

namespace GameRentalInvillia.Core.Common.Enum
{
    public enum Platform
    {
        [Display(Name = "PC")]
        PC,
        [Display(Name = "Nintendo Entertainment System")]
        NES,
        [Display(Name = "Super Nintendo Entertainment System")]
        SNES,
        [Display(Name = "Nintendo 64")]
        N64,
        [Display(Name = "Nintendo GameCube")]
        NGC,
        [Display(Name = "Nintendo Wii")]
        WII,
        [Display(Name = "Nintendo WiiU")]
        WIIU,
        [Display(Name = "Nintendo Switch")]
        SWITCH,
        [Display(Name = "Nintendo Game Boy")]
        GB,
        [Display(Name = "Nintendo Game Boy Color")]
        GBC,
        [Display(Name = "Nintendo Game Boy Advance")]
        GBA,
        [Display(Name = "Nintendo DS")]
        NDS,
        [Display(Name = "Nintendo 3DS")]
        N3DS,
        [Display(Name = "Sega Master System")]
        MASTER_SYSTEM,
        [Display(Name = "Sega Mega Drive")]
        MEGA_DRIVE,
        [Display(Name = "Sega Saturn")]
        SATURN,
        [Display(Name = "Sega Dreamcast")]
        DREAMCAST,
        [Display(Name = "Sega Game Gear")]
        GAME_GEAR,
        [Display(Name = "Sony PlayStation")]
        PS1,
        [Display(Name = "Sony PlayStation 2")]
        PS2,
        [Display(Name = "Sony PlayStation 3")]
        PS3,
        [Display(Name = "Sony PlayStation 4")]
        PS4,
        [Display(Name = "Sony PlayStation 5")]
        PS5,
        [Display(Name = "Sony PlayStation Portable")]
        PSP,
        [Display(Name = "Sony PlayStation Vita")]
        PSV,
        [Display(Name = "Microsoft Xbox")]
        XBOX,
        [Display(Name = "Microsoft Xbox 360")]
        X360,
        [Display(Name = "Microsoft Xbox One")]
        XONE,
        [Display(Name = "Microsoft Xbox Series X/S")]
        SERIESXS
    }
}