using Demo.DataAccess.Models.EmployeeModels.EmployeeEnums;
using Demo.DataAccess.Models.Shared.Enums;

namespace Demo.BusinessLogic.DataTransferObjects.EmployeeDTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Email { get; set; } = null!;
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public EmployeeTypes EmployeeType { get; set; }
        public Gender Gender { get; set; }



    }
}
