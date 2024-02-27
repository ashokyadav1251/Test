using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class Config
    {
        public static string BaseUrl = "https://www.themealdb.com/api/json/v1/1/";
        public static string Seafood = "filter.php?c=Seafood";
        public static string SeafoodDetails = "lookup.php?i={0}";
    }
}
