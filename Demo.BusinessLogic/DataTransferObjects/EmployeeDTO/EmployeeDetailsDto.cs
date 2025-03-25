using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models.EmployeeModels.EmployeeEnums;
using Demo.DataAccess.Models.Shared.Enums;

namespace Demo.BusinessLogic.DataTransferObjects.EmployeeDTO
{
    public  class EmployeeDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Address { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public string? PhoneNumber { get; set; } = null!;

        public DateTime HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeTypes EmployeeType { get; set; }



    }
}
