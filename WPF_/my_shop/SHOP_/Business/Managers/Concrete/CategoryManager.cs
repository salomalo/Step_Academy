using Business.Managers.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers.Concrete
{
    public class CategoryManager : AbstractManager, ICategoryManager
    {

        public CategoryManager(string cs) : base(cs) { }


        public IEnumerable<Categorys> GettAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Categorys>().ToList();
            }
        }
    }
}
