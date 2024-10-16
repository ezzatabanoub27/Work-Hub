using System.ComponentModel.DataAnnotations;

namespace Easy_Job.Data.Entities
{
    public class Job
    {
        [Key]
        public int Jib_Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; } 
        public string? Requirments { get; set; }
        public string? Location { get; set; }
        public int Salary { get; set; }
        public DateTime Created { get; set; }
        public string  appuser_Id { get; set; }

        public AppUser appuser { get; set; }= null!;
        public int company_Id { get; set; }
        public Company company { get; set; } = null!;

        public ICollection<Application> applications { get; }= new List<Application>();

    }
}
