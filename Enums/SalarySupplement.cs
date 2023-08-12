using System.ComponentModel.DataAnnotations;

namespace Budmar_app.Enums
{
    public enum SalarySupplement
    {
        [Display(Name = "Brak", Description = "Brak dodatku", Prompt = "B")]
        None,

        [Display(Name = "Dzienna zmiana", Description = "Pierwsze 8 godzin: stawka podstawowa, kolejne godziny dodatek 50%", Prompt = "D")]
        DailyShift,

        [Display(Name = "Noca zmiana", Description = "Dodatek 63% do każdej przepracowanej godziny", Prompt = "N")]
        NightShift,

        [Display(Name = "Dodatek weekendowy", Description = "Dodatek 100%", Prompt = "W")]
        WeekendBonus,

        [Display(Name = "Dodatek świąteczny", Description = "Dodatek 200%", Prompt = "S")]
        HolidaysBonus
    }
}
