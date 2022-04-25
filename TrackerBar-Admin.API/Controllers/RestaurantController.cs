using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrackerBar_Admin.API.DataModels;
using TrackerBar_Admin.API.Repositories;

namespace TrackerBar_Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRestaurantDirectionRepository _restaurantDirectionRepository;

        public RestaurantController(
            IRestaurantRepository restaurantRepository,
            IUserRepository userRepository,
            IRestaurantDirectionRepository restaurantDirectionRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _restaurantRepository = restaurantRepository;

            this.mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var restaurants = await _restaurantRepository.GetRestaurantsAsync();

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
                        Last = restaurant.User.Last,
                        UserName = restaurant.User.UserName,
                        Email = restaurant.User.Email,
                        BirthDate = restaurant.User.BirthDate
                    },
                    RestaurantDirection = new RestaurantDirection()
                    {
                        RestaurantDirectionId = restaurant.RestaurantDirection.RestaurantDirectionId,
                        Direction = restaurant.RestaurantDirection.Direction
                    }
                });
            }
            return Ok(domainModelRestaurants);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateRestaurants([FromBody] UpdateRestaurants restaurant)
        {
            var updatedRestaurant = await _restaurantRepository.UpdateRestaurantAsync(restaurant);

            var domainModel = new DomainModels.Restaurant();

            domainModel.RestaurantId = updatedRestaurant.RestaurantId;

            domainModel.RestaurantId = updatedRestaurant.RestaurantId;
            domainModel.Name = updatedRestaurant.Name;
            domainModel.PeopleQty = updatedRestaurant.PeopleQty;
            domainModel.TableQty = updatedRestaurant.TableQty;
            domainModel.Phone = updatedRestaurant.Phone;
            domainModel.User = new DomainModels.User(){
                Id = updatedRestaurant.User.Id,
                Name = updatedRestaurant.User.Name,
                Last = updatedRestaurant.User.Name,
                UserName = updatedRestaurant.User.UserName,
                Email = updatedRestaurant.User.Email,
                BirthDate = updatedRestaurant.User.BirthDate
            };
            domainModel.RestaurantDirection = new DomainModels.RestaurantDirection() {
                RestaurantDirectionId = updatedRestaurant.RestaurantDirection.RestaurantDirectionId,
                Direction = updatedRestaurant.RestaurantDirection.Direction
            };

            return Ok(domainModel);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteRestaurant([FromBody] DeleteRestaurant model) {
            var result = await _restaurantRepository.DeleteRestaurantAsync(model);

            if (result == null) {
                return BadRequest("User ID or Restaurant ID incorrect.");
            }
            return Ok("Restaurant deleted successfully!");
        }

        [HttpPost]
        [Route("AddRestaurant")]
        public async Task<IActionResult> AddRestaurant([FromBody]AddRestaurant newRestaurant)
        {
            var user = _userRepository.GetUserAsync(newRestaurant.UserId);
            var userExists = await _userRepository.GetUserExist(newRestaurant.UserId);
            var restaurantExists = await _restaurantRepository.GetRestaurantExist(newRestaurant.Name);
           
            if(userExists == true && restaurantExists == false)
            {
                var restaurant = await _restaurantRepository.AddRestaurant(newRestaurant);
                return Ok(restaurant);
            }
                return BadRequest();  
        }

        [HttpGet]
        [Route("yourRestaurants")]
        public async Task<IActionResult> YourRestaurant([FromBody]AddRestaurant YourRestaurant)
        {
            var user = await _userRepository.GetUserAsync(YourRestaurant.UserId);
            var userExists = await _userRepository.GetUserExist(YourRestaurant.UserId);
            var restaurantExists = await _restaurantRepository.GetRestaurantExist(YourRestaurant.Name);
           
            if (userExists == true && restaurantExists == false)
            {
                var restaurant = await _restaurantRepository.GetYourRestaurant(YourRestaurant.Name);
                return Ok(restaurant);
            }
            return BadRequest();
        }
    }
 }
