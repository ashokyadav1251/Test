using Test.DataAccess;
using Test.Models;
using Test.ViewModels;

namespace Test
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var result = Task.Run(() => GetListMeals().Result);
            mealsList.ItemsSource = result.Result;
        }

        public List<BaseMeal> baseMeals;
        public MealDetails mealDetails;
        public async Task<List<BaseMeal>> GetListMeals()
        {
            try
            {
                baseMeals = new List<BaseMeal>();
                HttpClient client = new HttpClient();
                HttpResponseMessage responseMessage = await client.GetAsync(Config.BaseUrl + Config.Seafood);
                var result = responseMessage.Content.ReadAsStringAsync();
                var finalresult = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(result.Result);
                baseMeals = finalresult?.meals;
                return baseMeals;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<MealDetails> GetMealDetails(string id)
        {
            try
            {
                mealDetails = new MealDetails();
                HttpClient client = new HttpClient();
                string url = Config.BaseUrl + string.Format(Config.SeafoodDetails, id);
                HttpResponseMessage responseMessage = await client.GetAsync(url);
                var result = responseMessage.Content.ReadAsStringAsync();
                var finalresult = Newtonsoft.Json.JsonConvert.DeserializeObject<RootDetails>(result.Result);
                mealDetails = finalresult?.Details;
                return mealDetails;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void mealsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var previous = e.PreviousSelection;
            var current = e.CurrentSelection[0];
            BaseMeal current1 = (BaseMeal)e.CurrentSelection[0];
            _ = GetMealDetails(current1.idMeal);
        }

    }

}
