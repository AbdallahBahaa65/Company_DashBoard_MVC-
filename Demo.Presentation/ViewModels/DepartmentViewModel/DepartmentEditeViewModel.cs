namespace Demo.Presentation.ViewModels.DepartmentViewModel
{
    public class DepartmentEditeViewModel
    {
        public string Name { get; set; }=string.Empty;
        public string Code { get; set; }=string.Empty ;
        public string? Description { get; set; }
        public DateOnly DateOfCreation { get; set; }
    }
}
