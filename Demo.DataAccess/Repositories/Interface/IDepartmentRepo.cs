namespace Demo.DataAccess.Repositories.Interface
{
    public interface IDepartmentRepo
    {
        int Add(Department department);
        IEnumerable<Department> GetAll(bool WithTracking = false);
        Department? GetById(int Id);
        int Remove(Department department);
        int Update(Department department);
    }
}