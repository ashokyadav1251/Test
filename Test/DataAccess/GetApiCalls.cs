using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.DataAccess
{
    internal class GetApiCalls : IGetApiCalls
    {
        public List<BaseMeal> baseMeals;
        public async Task<List<BaseMeal>> GetListMeals()
        {
            baseMeals = new List<BaseMeal>();
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(Config.BaseUrl);
            var result = responseMessage.Content.ReadAsStringAsync();
            var finalresult = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(result.Result);
            baseMeals = finalresult?.meals;
            return baseMeals;
        }
    }
}
