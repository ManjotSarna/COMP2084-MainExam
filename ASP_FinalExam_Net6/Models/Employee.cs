using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Sdk;

namespace ASP_FinalExam_Net6.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "An Employee Name is Required")]
        [StringLength(100)]
        public string Name { get; set; }
        public bool isManager { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
    }
}
