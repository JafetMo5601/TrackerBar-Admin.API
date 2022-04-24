using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TrackerBar_Admin.API.DataModels;
using TrackerBar_Admin.API.DB;
using TrackerBar_Admin.API.DomainModels;
using TrackerBar_Admin.API.Repositories;

namespace TrackerBar_Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUserRepository UserRepository;
        private readonly IMapper mapper;

        public RestaurantController(IRestaurantRepository restaurantRepository, IUserRepository UserRepository, IMapper mapper)
        {
            this.restaurantRepository = restaurantRepository;
            this.UserRepository = UserRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var restaurants = await restaurantRepository.GetRestaurantsAsync();

            var domainModelRestaurants = new List<DataModels.Restaurant>();

            foreach (var restaurant in restaurants)
            {
                domainModelRestaurants.Add(new DataModels.Restaurant()
                {
                    RestaurantId = restaurant.RestaurantId,
                    Name = restaurant.Name,
                    PeopleQty = restaurant.PeopleQty,
                    TableQty = restaurant.TableQty,
                    Phone = restaurant.Phone,
                    User = new DataModels.User()
                    {
                        Id = restaurant.User.Id,
                        Name = restaurant.User.Name,
                        Last = restaurant.User.Last,
                        UserName = restaurant.User.UserName,
                        Email = restaurant.User.Email,
                        BirthDate = restaurant.User.BirthDate
                    },
                    Direction = new DataModels.RestaurantDirection()
                    {
                        RestaurantDirectionId = restaurant.Direction.RestaurantDirectionId,
                        Direction = restaurant.Direction.Direction
                    }
                });
            }
            return Ok(domainModelRestaurants);
        }

        [HttpPost]
        [Route("AddRestaurant")]
        public async Task<IActionResult> AddRestaurant([FromBody]AddRestaurant newRestaurant)
        {
            var user = UserRepository.GetUserAsync(newRestaurant.UserId);
            var userExists = await UserRepository.GetUserExist(newRestaurant.UserId);
            var restaurantExists = await restaurantRepository.GetRestaurantExist(newRestaurant.Name);
           
            if(userExists == true && restaurantExists == false)
            {
                var restaurant = await restaurantRepository.AddRestaurant(newRestaurant);
                return Ok(restaurant);
            }
                return BadRequest();  
        }


        [HttpGet]
        [Route("yourRestaurants")]
        public async Task<IActionResult> YourRestaurant([FromBody]AddRestaurant YourRestaurant)
        {
            var user = await UserRepository.GetUserAsync(YourRestaurant.UserId);
            var userExists = await UserRepository.GetUserExist(YourRestaurant.UserId);
            var restaurantExists = await restaurantRepository.GetRestaurantExist(YourRestaurant.Name);
           
            if (userExists == true && restaurantExists == false)
            {
                var restaurant = await restaurantRepository.GetYourRestaurant(YourRestaurant.Name);
                return Ok(restaurant);
            }
            return BadRequest();
        }
    }
 }
