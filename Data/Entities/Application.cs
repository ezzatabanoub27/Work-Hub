using System.ComponentModel.DataAnnotations;

namespace Easy_Job.Data.Entities
{
    public class Application
    {
        [Key]
        public int Application_Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Status { get; set; }
        public DateTime App_Date { get; set; }
        
        public string appuser_Id { get; set; }
        public AppUser appuser { get; set; } = null!;

        public int job_Id { get; set; }
        public Job job { get; set; } = null!;



    }
}
