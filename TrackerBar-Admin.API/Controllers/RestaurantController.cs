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
            _restaurantDirectionRepository = restaurantDirectionRepository;

            this.mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateRestaurants([FromBody] UpdateRestaurants restaurant)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteRestaurant([FromBody] DeleteRestaurant model)
        {

            try
            {
                var result = await _restaurantRepository.DeleteRestaurantAsync(model);

                if (result == null)
                {
                    return BadRequest("User ID or Restaurant ID incorrect.");
                }
                return Ok("Restaurant deleted successfully!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Creates a new restaurant with the user parameters

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddRestaurant([FromBody]AddRestaurant newRestaurant)
        {
            try
            {
            var user = _userRepository.GetUserByIdAsync(newRestaurant.UserId);
            var restaurantExists = _restaurantRepository.restaurantExist(newRestaurant.RestaurantName);
           
            if(user != null && !restaurantExists)
            {
                var restaurant = await _restaurantRepository.AddRestaurant(newRestaurant);
                await _restaurantDirectionRepository.UpdateRestaurantDirectionAsync(restaurant.RestaurantId, newRestaurant.Direction);
                var updatedRestaurant = await _restaurantRepository.GetRestaurantByIdAsync(restaurant.RestaurantId);

                return Ok("Restaurant created successfully!");
            }
            return BadRequest("There is already an owned restaurant created with that name!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        //shows the owned restaurant the user put in the parameter
        [HttpGet]
        [Route("owned")]
        public async Task<IActionResult> YourRestaurant(string UserId, string RestaurantName)
        {
            try
            {
            var user = await _userRepository.GetUserByIdAsync(UserId);
            var restaurantExists = _restaurantRepository.restaurantExist(RestaurantName);
           
            if (user != null && restaurantExists) {
                var restaurant = await _restaurantRepository.GetYourRestaurant(RestaurantName);
                return Ok(restaurant);
            }
            return BadRequest("The restaurant does not exists, check the name and user id!");

            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
 }
