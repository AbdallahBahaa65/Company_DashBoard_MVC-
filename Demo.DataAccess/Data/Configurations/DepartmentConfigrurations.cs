namespace Demo.DataAccess.Data.Configurations
{
    internal class DepartmentConfigrurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id)
                   .UseIdentityColumn(10, 10);


            builder.Property(x => x.Name)
                .HasColumnType("Varchar(20)")
                .IsRequired();

            builder.Property(x => x.Code)
                .HasColumnType("Varchar(20)")
                .IsRequired();


            builder.Property(x => x.CreatedOn)
                .HasDefaultValueSql("GetDate()"); 
            
            builder.Property(x => x.LastModifiedOn)
                .HasComputedColumnSql("GetDate()");

        }
    }
}
