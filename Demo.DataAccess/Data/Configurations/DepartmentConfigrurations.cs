using Demo.DataAccess.Models.DepartmentModels;

namespace Demo.DataAccess.Data.Configurations
{
    internal class DepartmentConfigrurations :BaseEntityConfigration<Department>, IEntityTypeConfiguration<Department>
    {
        public  new void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id)
                   .UseIdentityColumn(10, 10);


            builder.Property(x => x.Name)
                .HasColumnType("Varchar(20)")
                .IsRequired();

            builder.Property(x => x.Code)
                .HasColumnType("Varchar(20)")
                .IsRequired();



            //Relation 1-M Between Employee and Department (Employee May Work In Department )

            builder.HasMany(E => E.Employees)
                   .WithOne(D => D.Department)
                   .HasForeignKey(E => E.DepartmentId)
                   .OnDelete(DeleteBehavior.SetNull);   

            base.Configure(builder);

           

        }
    }
}
