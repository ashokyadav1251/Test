﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.DataAccess
{
    public interface IGetApiCalls
    {
       Task<List<BaseMeal>> GetListMeals();
    }
}
