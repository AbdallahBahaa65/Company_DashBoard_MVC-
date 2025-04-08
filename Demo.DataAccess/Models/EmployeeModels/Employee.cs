namespace Demo.DataAccess.Models.EmployeeModels
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; } = null!;

        [Range(24, 50)]
        public int Age { get; set; }


        public string? Address { get; set; } = null!;
        public string? Email { get; set; } = null!;

        public bool IsActive { get; set; }
        public decimal Salary { get; set; }

        public string? PhoneNumber { get; set; } = null!;

        public DateTime HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeTypes EmployeeType { get; set; }

        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }




    }
}
