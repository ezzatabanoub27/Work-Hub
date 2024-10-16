using System.ComponentModel.DataAnnotations;

namespace Easy_Job.Data.Entities
{
    public class Company
    {
        [Key]
        public int Cpmany_Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string? Location { get; set; }
        public string? Website { get; set; }
        public string? Photo { get; set; }

        public ICollection<Job> jobs { get;}=new List<Job>();
    }
}
