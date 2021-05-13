using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Store_Angular.DDTO.DataAccess.Entity
{
    [Table("tbGames")]
    public class Games
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Game_name { get; set; }
        [Required]
        public string BriefDescription { get; set; }
        [Required]
        public string Вescription { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime Release_date { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Game_Icon { get; set; }
        [Required]
        public string Picture1 { get; set; }
        [Required]
        public string Picture2 { get; set; }
        [Required]
        public string Picture3 { get; set; }
        [Required]
        public string Picture4 { get; set; }
    }
}
