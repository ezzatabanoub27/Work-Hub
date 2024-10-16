namespace Easy_Job.Data.DTOs
{
    public class ProfileDTO
    {
        public string? Summery { get; set; }
        public IFormFile Resume_Path { get; set; }
        public IFormFile profile_Picture { get; set; }

        public string? Skills { get; set; }
        public string? Education { get; set; }
        public string? Experiences { get; set; }
        public string appuser_Id { get; set; }
    }
}
