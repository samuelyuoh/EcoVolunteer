using System.ComponentModel.DataAnnotations;

namespace MyCompany.Models
{
    public class Achievement
    {
        [Required]
        public int AchievementId { get; set; }
        [Required, MaxLength(30)]
        public string AchievementName { get; set; }
        [Required]
        public string AchievementDescription { get; set; }
        [Required]
        public string AchievementTitle { get; set; }
        [Required]
        public int ProgressRate { get; set; }
        [Required]
        public string Difficulty { get; set; }


        //To generate 1 to many relationship in db
        //public List<User>? Users { get; set; }
    }
}
