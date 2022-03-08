using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackerBar_Admin.API.DomainModels;
using TrackerBar_Admin.API.Repositories;

namespace TrackerBar_Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IMapper mapper;

        public RestaurantController(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            this.restaurantRepository = restaurantRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllRestaurants() 
        {
            var restaurants = await restaurantRepository.GetRestaurantsAsync();

            var domainModelRestaurants = new List<Restaurant>();

            foreach (var restaurant in restaurants)
            {
                domainModelRestaurants.Add(new Restaurant()
                {
                    RestaurantId = restaurant.RestaurantId,
                    Name = restaurant.Name,
                    PeopleQty = restaurant.PeopleQty,
                    TableQty = restaurant.TableQty,
                    Phone = restaurant.Phone,
                    User = new User()
                    {
                        Id = restaurant.User.Id,
                        Name = restaurant.User.Name,
                        Last = restaurant.User.Name,
                        UserName = restaurant.User.UserName,
                        Email = restaurant.User.Email,
                        BirthDate = restaurant.User.BirthDate
                    },
                    Direction = new RestaurantDirection()
                    {
                        RestaurantDirectionId = restaurant.Direction.RestaurantDirectionId,
                        Direction = restaurant.Direction.Direction
                    }
                });
            }
            return Ok(domainModelRestaurants);
        }
    }
}
