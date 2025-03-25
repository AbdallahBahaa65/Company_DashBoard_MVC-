using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Interface
{
    public interface IGenaricRepository<TEntity> where TEntity : BaseEntity
    {
        public IEnumerable<TEntity> GetAll(bool withTracking = false);
        public TEntity GetById(int id);

        public int Update(TEntity employee);
        public int Remove(TEntity employee);
        public int Add(TEntity employee);
    }
}
