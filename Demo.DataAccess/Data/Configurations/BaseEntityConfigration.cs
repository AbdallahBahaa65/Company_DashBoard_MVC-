using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Configurations
{
    public class BaseEntityConfigration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.CreatedOn)
               .HasDefaultValueSql("GetDate()");

            builder.Property(x => x.LastModifiedOn)
                .HasComputedColumnSql("GetDate()");
        }
    }
}
