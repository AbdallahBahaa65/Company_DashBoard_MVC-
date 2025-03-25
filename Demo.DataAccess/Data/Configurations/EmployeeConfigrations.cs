using Demo.DataAccess.Models.EmployeeModels;
namespace Demo.DataAccess.Data.Configurations
{
    public class EmployeeConfigrations : BaseEntityConfigration<Employee>, IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).IsRequired().HasColumnType("nVarchar(50)");


            builder.Property(E => E.Address).HasColumnType("nVarchar(150)");
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");


            builder.Property(E => E.Gender).HasConversion((EmpGendar) => EmpGendar.ToString() /*From Enum To Data Base*/
                                                          , ((ReturnGender) => (Gender)Enum.Parse(typeof(Gender), ReturnGender) /*From DB To Enum */));


            builder.Property(E => E.EmployeeType).HasConversion((EmpType) => EmpType.ToString() /*From Enum To Data Base*/
                                               , ((ReturnEmpType) => (EmployeeTypes)Enum.Parse(typeof(EmployeeTypes), ReturnEmpType) /*From DB To Enum */));

            
            base.Configure(builder);






        }
    }
}
