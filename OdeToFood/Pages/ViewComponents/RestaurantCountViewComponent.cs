using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.Pages.ViewComponents
{
    public class RestaurantCountViewComponent: ViewComponent
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = _restaurantData.GetCountOfRestaurants();
            return View(count);
        }
    }
}
