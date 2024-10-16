using System.ComponentModel.DataAnnotations;

namespace Easy_Job.Data.DTOs
{
    public class CompanyDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Location { get; set; }
        public string? Website { get; set; }
        public IFormFile? Photo { get; set; }

    }
}
