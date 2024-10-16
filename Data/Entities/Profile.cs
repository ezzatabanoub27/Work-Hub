using System.ComponentModel.DataAnnotations;

namespace Easy_Job.Data.Entities
{
    public class Profile
    {
        [Key]
        public int Profile_Id { get; set; }
        public string? Summery { get; set; }
        public string? Resume_Path { get; set; }
        public string? Skills { get; set; }
        public string? Education { get; set; }
        public string? profile_Picture { get; set; }

        public string? Experiences { get; set; }
        public string appuser_Id { get; set; }
        public AppUser appuser { get; set; } = null!;
    }
}
