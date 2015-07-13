using BS.Business.Managers.Abstract;
using BS.LinqToSql;
using System.Collections.Generic;

namespace BS.Business.Managers.Linq
{
    public class LinqCategoryManager : ICategoryManager
    {
        public IEnumerable<Entities.Category> GetAll()
        {
            using (BSDataContext ctx = new BSDataContext())
            {
                List<Entities.Category> res = new List<Entities.Category>();

                foreach(var c in ctx.Categories)
                {
                    res.Add(new Entities.Category { 
                        Id = c.Id,
                        Name = c.Name,
                        ParentId = c.ParentId
                    });
                }

                return res;
            }
        }
    }
}
