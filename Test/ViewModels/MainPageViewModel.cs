using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess;

namespace Test.ViewModels
{
    public class MainPageViewModel
    {
        public IGetApiCalls _getApiCalls;
        public MainPageViewModel(IGetApiCalls getApiCalls)
        {
            _getApiCalls = getApiCalls;
            GetApiCalls();
        }

        public void GetApiCalls()
        {
            var result = _getApiCalls.GetListMeals();
        }
    }
}
