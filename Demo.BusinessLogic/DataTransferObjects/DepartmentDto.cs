namespace Demo.BusinessLogic.DataTransferObjects
{
    public  class DepartmentDto
    {
        public int DeptId { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        public DateOnly DateOfCreation { get; set; }

    }
}
