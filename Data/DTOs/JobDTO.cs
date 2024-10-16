using System.ComponentModel.DataAnnotations;

namespace Easy_Job.Data.DTOs
{
    public class JobDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Requirments { get; set; }
        public string? Location { get; set; }
        public int Salary { get; set; }
        public DateTime Created { get; set; }
        public int company_Id { get; set; }
        public string appuser_Id { get; set; }
    }
}
