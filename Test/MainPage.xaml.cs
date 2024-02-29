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
                var finalresult = Newtonsoft.Json.JsonConvert.DeserializeObject<Root1>(result.Result);
                mealDetails = finalresult?.meals?.FirstOrDefault();
                return mealDetails;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private async void mealsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var previous = e.PreviousSelection;
                var current = e.CurrentSelection[0];
                BaseMeal current1 = (BaseMeal)e.CurrentSelection[0];
           
                var obj = Task.Run(()=> GetMealDetails(current1.idMeal));
                
                MealDetails meals = new MealDetails
                {
                    strMeal = mealDetails.strMeal // obj.strMeal,
                    //strMealThumb = obj.strMealThumb,
                    //strImageSource = obj.strImageSource,
                };
              await  Navigation.PushAsync(new DetailsPage { BindingContext = meals });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
