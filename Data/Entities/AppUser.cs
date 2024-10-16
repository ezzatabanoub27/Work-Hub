using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Easy_Job.Data.Entities
{
    public class AppUser:IdentityUser 
    {
        public int UserI_d {get; set;}
        [Required]
        [MaxLength(100)]
        public string Name  { get; set;}
        [Required]
        [MaxLength(100)]
        public string Email { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]

        public string UserType { get; set; }

        public ICollection<Application> applications { get; }=new List<Application>();
        public ICollection<Job> jobs { get; }=new List<Job>();
        public Profile? profile { get; set; }


    }
}
