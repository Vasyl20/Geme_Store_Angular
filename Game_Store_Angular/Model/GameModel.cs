using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Store_Angular.Model
{
    public class GameModel 
    { 
        public int Id { get; set; }
        public string Game_name { get; set; }
        public string BriefDescription { get; set; }
        public string Вescription { get; set; }
        public int Price { get; set; }
        public DateTime Release_date { get; set; }
        public string Genre { get; set; }
        public string Game_Icon { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
        public string Picture3 { get; set; }
        public string Picture4 { get; set; }
    }

    public class CreatGameModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введіть імя ігри")]
        public string Game_name { get; set; }

        [Required(ErrorMessage = "Введіть короткий опис ігри")]
        public string BriefDescription { get; set; }

        [Required(ErrorMessage = "Введіть повний опис ігри")]
        public string Вescription { get; set; }

        [Required(ErrorMessage = "Введіть ціну ігри")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Введіть дату випоску")]
        public DateTime Release_date { get; set; }

        [Required(ErrorMessage = "Введіть жанри")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Введіть картику ігри")]
        public string Game_Icon { get; set; }

        [Required(ErrorMessage = "Введіть картику")]
        public string Picture1 { get; set; }

        [Required(ErrorMessage = "Введіть картику")]
        public string Picture2 { get; set; }

        [Required(ErrorMessage = "Введіть картику")]
        public string Picture3 { get; set; }

        [Required(ErrorMessage = "Введіть картику")]
        public string Picture4 { get; set; }
    }
}
