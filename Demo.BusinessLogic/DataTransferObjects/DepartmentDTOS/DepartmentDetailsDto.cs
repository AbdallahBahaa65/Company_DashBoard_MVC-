namespace Demo.BusinessLogic.DataTransferObjects.DepartmentDTOS
{
    public class DepartmentDetailsDto
    {
        public int Id { get; set; } // PK 
        public int CreatedBy { get; set; } //User Id    

        public int LastModifiedBy { get; set; } // User Id 

        public DateOnly CreatedOn { get; set; }
        public DateOnly LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; } // Soft  Delete 

        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }

    }
}
