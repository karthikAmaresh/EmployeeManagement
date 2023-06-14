using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public int age { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public string eyeColor { get; set; }
        [Required]
        public string company { get; set; }
        [Required]
        public string email { get; set; }
        public long phone { get; set; }
        public string address { get; set; }
        public string about { get; set; }
    }
}
