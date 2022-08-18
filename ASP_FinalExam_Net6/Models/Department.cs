using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace ASP_FinalExam_Net6.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "A Department Name is Required")]
        [StringLength(100)]
        public string Name { get; set; }
        [Range(0,int.MaxValue)]
        public int EmployeeCount { get; set; }
    }
}
