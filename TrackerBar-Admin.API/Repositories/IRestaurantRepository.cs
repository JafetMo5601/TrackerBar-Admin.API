﻿using TrackerBar_Admin.API.DataModels;

namespace TrackerBar_Admin.API.Repositories
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetRestaurantsAsync();
        Task<Restaurant> UpdateRestaurantAsync(UpdateRestaurants restaurant);
        Task<Restaurant> GetRestaurantByIdAsync(int restaurantId);
        Task<Restaurant> DeleteRestaurantAsync(DeleteRestaurant deleteRestaurant);
        Task<string> GetNameRestaurant(string RestaurantName);
        Task<bool> GetRestaurantExist(string RestaurantName);
        Task<Restaurant> GetYourRestaurant(string RestaurantName);
        Task<Restaurant> AddRestaurant(AddRestaurant newRestaurant);
    }
}
