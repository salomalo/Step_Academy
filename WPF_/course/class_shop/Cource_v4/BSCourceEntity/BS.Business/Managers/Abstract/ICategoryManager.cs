﻿using BS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Business.Managers.Abstract
{
    public interface ICategoryManager : IManager
    {
        IEnumerable<Categories> GetAll();
        void Insert(Categories category);
        void Update(int Id, string name);
    }
}